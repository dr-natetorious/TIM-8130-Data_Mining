$csv = Import-CSV .\PatientSurvey.csv
echo "State,Score,Topic,Question,Rating"|out-File -FilePath Cleaned.csv -encoding utf8 -Force
foreach($row in $csv){
    ($h,$category,$index,$range_start,$range_end) = $row.'HCAHPS Measure ID'.Split('_')
    $state = $row.State
    $selection = [string]::join("_", ($range_start,$range_end))

    $score = $row.'HCAHPS Answer Percent'
    if ($score -eq 'Not Available'){
        $score = [string]::empty
    } else {
        $score = [double]::parse($score)/100.0
    }
        
    "$state,$score,$category,$index,$selection" | Out-File -FilePath Cleaned.csv -encoding utf8 -Append
}
