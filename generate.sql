Set nocount on;
declare @bd varchar(max), @Models int, @MissingSQLModels int, @MissingViewModels int
  select @Models = count(*), @MissingSQLModels = sum(case when SQL_ScriptOutputFlag = 0 then 1 else 0 end), @MissingViewModels = sum(case when ScoringViewReadyFlag = 0 then 1 else 0 end) from [mrtMeritBaseDatamartX].[PINNACLE].[ModelMeta] where ModelStatus = 'AA';

  SET @bd = cast( (
	SELECT td = ModelNo + '</td><td>' + ModelName +'</td><td>' + DAPP_ModelText + '</td><td class="num">'+ Ranks + '</td>' + case when Err1 = 0 then '<td>' else '<td class="err">' end + SQL_ScriptOutput + '</td>'+ case when Err2 = 0 then '<td>' else '<td class="err">' end + ScoringViewReady
	FROM (
     SELECT Top 100 PERCENT  ModelNo
            ,ModelName
			,ModelStatus
			,DAPP_ModelText
            ,Ranks = cast(ModelRanksCount as varchar(3))
			, SQL_ScriptOutput = case SQL_ScriptOutputFlag when 1 then 'Yes' else 'No' end
			, ScoringViewReady = case ScoringViewReadyFlag when 1 then 'Yes' else 'No' end
			, Err1 = case when SQL_ScriptOutputFlag = 0  then 1 else 0 end
			, Err2 = case when ScoringViewReadyFlag = 0  then 1 else 0 end
    FROM    [mrtMeritBaseDatamartX].[PINNACLE].[ModelMeta] 
	WHERE ModelStatus = 'AA'
	
      ) AS d order by ModelNo
FOR XML PATH( 'tr' ), type ) as varchar(max) );



SET @bd = '<table>'
              + '<tr><th>ModelNumber</th><th>ModelName</th><th>DAPP_ModelText</th><th>Ranks</th><th>SQLScriptOutput</th><th>SQLScoringViewReady</th></tr>'
              + replace( replace( @bd, '&lt;', '<' ), '&gt;', '>' )
              + '</table><br/>';

SET @bd = '<table>
<tr class="bold"><td >Models to run: </td><td>' + cast(@Models as varchar(3)) + '<td></tr>
<tr class="bold"><td>Missing Scripts: </td><td>' + cast(@MissingSQLModels as varchar(3)) + '</td></tr>
<tr class="bold"><td>Missing Views: </td><td>' + cast(@MissingViewModels as varchar(3)) + '</td></tr>
</table>
<br/>' + @bd;


SET @bd =  '<style>
table {font-family: arial; border: solid black 1px;  border-spacing: 2; border-collapse: separate;}
th {text-align: left; font-weight: bold; border-bottom: solid black 1px}
td {padding-left: 4px; padding-right: 4px; }
td.num {text-align: right;}
td.err {text-align: right; font-weight: bold; background-color: #FFFF00}
tr.bold {text-align: left; font-weight: bold;}
td.note {font-size: smaller}
td.final {border-top: solid black 2px; font-weight: bold}
td.finalamount {text-align: right;border-top: solid black 2px; font-weight: bold}
</style>' + @bd;

select @bd as body;

