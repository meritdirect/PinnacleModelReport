﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.91.37.174;Initial Catalog=mrtMeritBaseDatamartX;Trusted_Connection"& _ 
            "=True")>  _
        Public ReadOnly Property conDatamart() As String
            Get
                Return CType(Me("conDatamart"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=10.91.37.180;Initial Catalog=PinnacleModelRescore;User ID=jbarash;Pas"& _ 
            "sword=Northern#Lights!;MultipleActiveResultSets=true")>  _
        Public ReadOnly Property conThomagata() As String
            Get
                Return CType(Me("conThomagata"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("\\10.91.37.180\e$\Pinnacle\Model Rescore Process\PINNACLE MODELS\SQL_Code\ScriptP"& _ 
            "rocessing\")>  _
        Public ReadOnly Property ScriptDIR() As String
            Get
                Return CType(Me("ScriptDIR"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Set nocount on;"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"declare @bd varchar(max), @Models int, @MissingSQLModels int, @M"& _ 
            "issingViewModels int"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"  select @Models = count(*), @MissingSQLModels = sum(case "& _ 
            "when SQL_ScriptOutputFlag = 0 then 1 else 0 end), @MissingViewModels = sum(case "& _ 
            "when ScoringViewReadyFlag = 0 then 1 else 0 end) from [mrtMeritBaseDatamartX].[P"& _ 
            "INNACLE].[ModelMeta] where ModelStatus = 'AA';"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"  SET @bd = cast( ("&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"SELECT t"& _ 
            "d = ModelNo + '</td><td>' + ModelName +'</td><td>' + DAPP_ModelText + '</td><td "& _ 
            "class=""num"">'+ Ranks + '</td>' + case when Err1 = 0 then '<td>' else '<td class="& _ 
            """err"">' end + SQL_ScriptOutput + '</td>'+ case when Err2 = 0 then '<td>' else '<"& _ 
            "td class=""err"">' end + ScoringViewReady"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"FROM ("&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"     SELECT Top 100 PERCENT  M"& _ 
            "odelNo"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"            ,ModelName"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&",ModelStatus"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&",DAPP_ModelText"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"           "& _ 
            " ,Ranks = cast(ModelRanksCount as varchar(3))"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&", SQL_ScriptOutput = case SQL_"& _ 
            "ScriptOutputFlag when 1 then 'Yes' else 'No' end"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&", ScoringViewReady = case S"& _ 
            "coringViewReadyFlag when 1 then 'Yes' else 'No' end"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&", Err1 = case when SQL_S"& _ 
            "criptOutputFlag = 0  then 1 else 0 end"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(9)&", Err2 = case when ScoringViewReadyFl"& _ 
            "ag = 0  then 1 else 0 end"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"    FROM    [mrtMeritBaseDatamartX].[PINNACLE].[Model"& _ 
            "Meta] "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"WHERE ModelStatus = 'AA'"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"      ) AS d order by ModelNo"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"FOR XML PAT"& _ 
            "H( 'tr' ), type ) as varchar(max) );"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET @bd = '<table>'"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"              +"& _ 
            " '<tr><th>ModelNumber</th><th>ModelName</th><th>DAPP_ModelText</th><th>Ranks</th"& _ 
            "><th>SQLScriptOutput</th><th>SQLScoringViewReady</th></tr>'"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"              + rep"& _ 
            "lace( replace( @bd, '&lt;', '<' ), '&gt;', '>' )"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"              + '</table><br/>"& _ 
            "';"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET @bd = '<table>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<tr class=""bold""><td >Models to run: </td><td>' + cast"& _ 
            "(@Models as varchar(3)) + '<td></tr>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<tr class=""bold""><td>Missing Scripts: </td"& _ 
            "><td>' + cast(@MissingSQLModels as varchar(3)) + '</td></tr>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<tr class=""bold""><"& _ 
            "td>Missing Views: </td><td>' + cast(@MissingViewModels as varchar(3)) + '</td></"& _ 
            "tr>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"</table>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<br/>' + @bd;"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET @bd =  '<style>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"table {font-family: arial"& _ 
            "; border: solid black 1px;  border-spacing: 2; border-collapse: separate;}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"th {"& _ 
            "text-align: left; font-weight: bold; border-bottom: solid black 1px}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td {paddin"& _ 
            "g-left: 4px; padding-right: 4px; }"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td.num {text-align: right;}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td.err {text-al"& _ 
            "ign: right; font-weight: bold; background-color: #FFFF00}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"tr.bold {text-align: "& _ 
            "left; font-weight: bold;}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td.note {font-size: smaller}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td.final {border-top: s"& _ 
            "olid black 2px; font-weight: bold}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td.finalamount {text-align: right;border-top"& _ 
            ": solid black 2px; font-weight: bold}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"</style>' + @bd;"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"select @bd as body;"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)& _ 
            "")>  _
        Public ReadOnly Property sqlCode() As String
            Get
                Return CType(Me("sqlCode"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Set nocount on;"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"declare @bd varchar(max), @Models int, @MissingSQLModels int, @M"& _ 
            "issingViewModels int"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"  select @Models = count(*), @MissingSQLModels = sum(case "& _ 
            "when SQL_ScriptOutputFlag = 0 then 1 else 0 end), @MissingViewModels = sum(case "& _ 
            "when ScoringViewReadyFlag = 0 then 1 else 0 end) from [mrtMeritBaseDatamartX].[P"& _ 
            "INNACLE].[ModelMeta] where ModelStatus = 'AA';"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET @bd = '<table>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<tr class="& _ 
            """bold""><td >Models to run: </td><td>' + cast(@Models as varchar(3)) + '<td></tr>"& _ 
            ""&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<tr class=""bold""><td>Missing Scripts: </td><td>' + cast(@MissingSQLModels as v"& _ 
            "archar(3)) + '</td></tr>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<tr class=""bold""><td>Missing Views: </td><td>' + cast("& _ 
            "@MissingViewModels as varchar(3)) + '</td></tr>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"</table>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<br/>';"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET @bd "& _ 
            "=  '<style>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"table {font-family: arial; border: solid black 1px;  border-spacing"& _ 
            ": 2; border-collapse: separate;}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"th {text-align: left; font-weight: bold; borde"& _ 
            "r-bottom: solid black 1px}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td {padding-left: 4px; padding-right: 4px; }"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td.num"& _ 
            " {text-align: right;}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td.err {text-align: right; font-weight: bold; background-"& _ 
            "color: #FFFF00}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"tr.bold {text-align: left; font-weight: bold;}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td.note {font-s"& _ 
            "ize: smaller}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td.final {border-top: solid black 2px; font-weight: bold}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"td.fin"& _ 
            "alamount {text-align: right;border-top: solid black 2px; font-weight: bold}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"</s"& _ 
            "tyle>' + @bd;"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"select @bd as body;"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))>  _
        Public ReadOnly Property sqlCode2() As String
            Get
                Return CType(Me("sqlCode2"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("5")>  _
        Public ReadOnly Property maxThreads() As Integer
            Get
                Return CType(Me("maxThreads"),Integer)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.PinnacleModelReport.My.MySettings
            Get
                Return Global.PinnacleModelReport.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
