Public Class clsScoring
    Public _ConnectionString As String = String.Empty
    Public _ScoringView As String = String.Empty

    Public Sub New(ByVal strConnectionString As String, ByVal strScoringView As String)
        _ConnectionString = strConnectionString
        _ScoringView = strScoringView

    End Sub
    Public Sub Run()
        Using conn As New SqlClient.SqlConnection(_ConnectionString)
            conn.Open()
            Using cmd As New SqlClient.SqlCommand()
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "declare @nCount int
                                    Select @nCount = Count(*) from [" & _ScoringView & "]
                                    Update ModelReportCounts set [Count] = @nCount where ScoringView = '" & _ScoringView & "'"
                cmd.CommandTimeout = 0
                Try
                    cmd.ExecuteNonQuery()
                Catch exsql As SqlClient.SqlException
                    'log error here
                Catch ex As Exception
                    'log error here
                End Try
            End Using
        End Using

    End Sub
End Class
