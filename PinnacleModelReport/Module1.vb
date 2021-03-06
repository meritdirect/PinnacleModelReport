﻿Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Threading
Imports Microsoft.SqlServer.Dts.Runtime

Module Module1

    Sub Main()
        Dim strFileName As String = "", strViewName As String = "", strModelTable As String = "", bFound As Boolean = False
        Dim strMessage As New StringBuilder, strErrorTable As New StringBuilder
        Dim sConnection As String = My.Settings.conDatamart


        PopulateCounts()
        If My.Application.CommandLineArgs.Count = 0 Then
            Try
                PopulateScoringTable()
                'replaced with direct query using linked server
                'Dim app As Microsoft.SqlServer.Dts.Runtime.Application
                'Dim pkg As Microsoft.SqlServer.Dts.Runtime.Package
                'app = New Microsoft.SqlServer.Dts.Runtime.Application()
                'app.PackagePassword = "password"
                'pkg = app.LoadPackage("E:\Pinnacle\Model Rescore Process\SSIS - Rewrite\ModelManager\ModelManager\UpdateModelManager.dtsx", Nothing)
                'pkg.PackagePassword = "password"

                'pkg.Execute()
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
            End Try

            Using ConThomagata As New SqlConnection(My.Settings.conThomagata)
                ConThomagata.Open()


                Using cmd As New SqlCommand()
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 0
                    cmd.Connection = ConThomagata
                    cmd.CommandText = "p_ModelTable"
                    strModelTable = cmd.ExecuteScalar().ToString
                    End Using ' command

                    strMessage.Append("<table>")
                Using Com As New SqlCommand("SELECT ModelNo, ScoringView from [MRTDATAMART1].[mrtMeritBaseDatamartX].PINNACLE.ModelMeta where ModelStatus='AA' order by ModelNo", ConThomagata)
                    Using RDR = Com.ExecuteReader()
                        If RDR.HasRows Then
                            Do While RDR.Read
                                Console.Write(".")
                                strFileName = RDR("ModelNo").ToString() & "_Source_CD_" & Mid(RDR("ModelNo").ToString, 2, 3) & ".sql"
                                If String.IsNullOrEmpty(RDR("ScoringView").ToString) Then
                                    strViewName = RDR("ModelNo").ToString & "_SCORING_VIEW"
                                Else
                                    strViewName = RDR("ScoringView").ToString.Replace("VIEW3", "VIEW") ' exception for 02650001, 02650002
                                    strViewName = strViewName.Replace("00280001H", "00280001") ' exception for misnamed scoring views
                                    strViewName = strViewName.Replace("00280002H", "00280002")
                                End If
                                If Not ViewExists(strViewName, ConThomagata) Then
                                    strMessage.Append("<tr><td>" & strViewName & " Missing" & "</td></tr>")
                                    bFound = True
                                End If
                                If Not File.Exists(My.Settings.ScriptDIR & strFileName) Then
                                    strMessage.Append("<tr><td>" & strFileName & " Missing" & "</td></tr>")
                                    bFound = True
                                End If
                            Loop
                        End If
                    End Using ' RDR
                    If Not bFound Then
                        strMessage.Append("<tr><td>No Missing Scripts or Views </td></tr>")
                    End If

                End Using ' Com


                strMessage.Append("</table><br/><br/>")
                'Using cmdT As New SqlCommand
                '    With cmdT
                '        .CommandType = CommandType.StoredProcedure
                '        .CommandText = "p_GetLatestViewCounts"
                '        .Connection = ConThomagata
                '        .CommandTimeout = 0
                '        strMessage.Append(.ExecuteScalar().ToString)
                '    End With
                'End Using
                'strMessage.Append("<br/><br/>")
                strMessage.Append(strModelTable)

                SendSQLEmail(strMessage.ToString, "PinnacleModelReport", ConThomagata)
            End Using 'ConThomagata
        End If 'no command line arguments
    End Sub
    Public Sub SendSQLEmail(strBody As String, strSubject As String, Con As SqlConnection)
        Dim sConnection As String = My.Settings.conThomagata
        Using Com As New SqlCommand("senderroremail", Con)
            Com.CommandTimeout = 0
            Com.CommandType = CommandType.StoredProcedure
            Com.Parameters.Add("@Body", SqlDbType.VarChar)
            Com.Parameters("@Body").Value = strBody
            Com.Parameters.Add("@Sub", SqlDbType.VarChar)
            Com.Parameters("@Sub").Value = strSubject
            Com.Parameters.Add("@QRY", SqlDbType.VarChar)
            'Com.Parameters("@QRY").Value = "exec p_PreRescoreCount"
            Com.Parameters("@QRY").Value = "SET NOCOUNT ON;Select Model, ModelDescription, DAPP_ModelText, REPLACE(CONVERT(varchar(20), (CAST([Count] AS money)), 1), '.00', '') as [Count], Score, REPLACE(CONVERT(varchar(20), (CAST(CASE when [Count]=0 THEN 0 ELSE CEILING(cast([Count] as FLOAT)/CAST(Score as FLOAT)) END AS money)), 1), '.00', '') as CountPerRank, SQLScoringViewReady, SQLScriptOutput from ModelReportCounts ORDER BY Model"
            Com.Parameters.Add("@FILENAME", SqlDbType.VarChar)
            Com.Parameters("@FILENAME").Value = "PinnacleRescoreCounts.csv"
            Com.Parameters.Add("@DATABASE", SqlDbType.VarChar)
            Com.Parameters("@DATABASE").Value = "PinnacleModelRescore"
            Com.ExecuteNonQuery()
        End Using
    End Sub
    Public Function ViewExists(strViewName As String, Con As SqlConnection) As Boolean
        Dim strSQL As String = ""
        strSQL = "Select Count(*) from sys.views where name='" & strViewName & "'"
        Using Com As New SqlCommand(strSQL, Con)
            Try
                Com.CommandType = CommandType.Text
                Dim ret As Integer = DirectCast(Com.ExecuteScalar, Integer)
                If ret > 0 Then
                    ViewExists = True
                Else
                    ViewExists = False
                End If
            Catch ex As Exception
                ViewExists = False
            End Try
        End Using

    End Function
    Public Sub PopulateCounts()
        Dim dic As New List(Of Threading.Thread)
        Dim cScoring As clsScoring
        Dim maxThreads As Integer = My.Settings.maxThreads
        Dim i As Integer = 0
        Dim nCount As Integer = 0

        Dim sConnection As String = My.Settings.conThomagata
        Using Con As New SqlConnection(sConnection)
            Con.Open()
            Using cmd As New SqlCommand()
                cmd.CommandType = CommandType.Text
                cmd.Connection = Con
                cmd.CommandText = "Truncate table ModelReportCounts                                    
                                    Insert into ModelReportCounts
                                    select 
	                                    v.name as ScoringView,
                                         M.ModellingFieldName as Model,
	                                    isnull(M.ModelName,'') as ModelDescription,
	                                     DAPP_ModelText,
	                                    0 as [Count],
	                                     M.ModelRanksCount as Score,
	                                    Case M.SQL_ScriptOutputFlag when 1 then 'YES' ELSE 'NO' END as SQLScoringViewReady,
	                                    Case M.ScoringViewReadyFlag when 1 then 'YES' ELSE 'NO' END as SQLScriptOutput   
                                    from  [MRTDATAMART1].[mrtMeritBaseDatamartX].[PINNACLE].[ModelMeta] M                                    
                                    LEFT OUTER JOIN sys.views v on v.Name = M.ModelNo + '_Scoring_View'
                                    where M.ModelStatus='AA'
                                    order by M.ModelNo"
                cmd.ExecuteNonQuery()
            End Using
            Using Com As New SqlCommand("SELECT * from ModelReportCounts", Con)
                Using RDR = Com.ExecuteReader()
                    If RDR.HasRows Then
                        Do While RDR.Read
                            cScoring = New clsScoring(My.Settings.conThomagata, RDR("ScoringView").ToString)
                            Dim tr As New Threading.Thread(AddressOf cScoring.Run)
                            tr.IsBackground = True
                            tr.Start()
                            dic.Add(tr)
                            Do While treadCount(dic) >= maxThreads
                                Threading.Thread.Sleep(1000)
                            Loop

                        Loop 'RDR.Read
                    End If 'RDR has rows
                End Using 'RDR
            End Using 'Com
            Con.Close()
        End Using 'Con

        Do While treadCount(dic) > 0 'wait for threads to finish
            Threading.Thread.Sleep(1000)
        Loop


    End Sub
    Public Sub PopulateScoringTable()


        Dim sConnection As String = My.Settings.conThomagata
        Using Con As New SqlConnection(sConnection)
            Con.Open()
            Using cmd As New SqlCommand()
                cmd.CommandType = CommandType.Text
                cmd.Connection = Con
                cmd.CommandText = "
                Truncate table zPinnacle_Score_Process_Table;
    Insert into zPinnacle_Score_Process_Table (MODEL_NUMBER, MODEL_NAME, TYPE1, SQL_SOURCE_CODE, SCORE_METHOD, FORMAT_SEQ, APPLY_MODEL, Status)
    Select ModelNo as MODEL_NUMBER, ModellingFieldName as MODEL_NAME,  ModelName as TYPE1, ModellingFieldName + '.sql' as SQL_SOURCE_CODE, ModelRanksCount as SCORE_METHOD, ModelID as FORMAT_SEQ, CASE when ModelStatus = 'AA' THEN 'Y' ELSE 'N' END, 0 as Status FROM [MRTDATAMART1].[mrtMeritBaseDatamartX].[PINNACLE].[ModelMeta]"
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function treadCount(dic As List(Of Thread)) As Integer
        Dim nRet As Integer = 0
        For Each tr As Thread In dic
            If tr.IsAlive Then
                nRet += 1
            End If
        Next
        Return nRet
    End Function

End Module
