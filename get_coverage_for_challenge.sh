#!/usr/bin/env bash

set -x

CHALLENGE_ID=$1
CODE_COVERAGE_OUTPUT_FILE="./coverage.tdl"

dotnet build

coverlet_settings_file=$(mktemp)
cat << EOF > ${coverlet_settings_file}
<?xml version="1.0" encoding="utf-8" ?>
<RunSettings>
  <DataCollectionRunSettings>
    <DataCollectors>
      <DataCollector friendlyName="XPlat code coverage">
        <Configuration>
          <Format>cobertura</Format>
          <Include>[*]BeFaster.App.Solutions.${CHALLENGE_ID}.*</Include>
          <SingleHit>true</SingleHit>
          <SkipAutoProps>true</SkipAutoProps>
          <DeterministicReport>false</DeterministicReport>
        </Configuration>
      </DataCollector>
    </DataCollectors>
  </DataCollectionRunSettings>
</RunSettings>
EOF

dotnet test --collect:"XPlat Code Coverage" --settings ${coverlet_settings_file}
last_test_run_id=$(ls -rt1 ./src/BeFaster.App.Tests/TestResults/  | tail -n 1)

computed_coverage_rate=$(xmllint ./src/BeFaster.App.Tests/TestResults/${last_test_run_id}/coverage.cobertura.xml  --xpath 'string(/coverage/@line-rate)')
printf "%.0f\n" $(echo "$computed_coverage_rate*100" | bc -l)   > ${CODE_COVERAGE_OUTPUT_FILE}
cat ${CODE_COVERAGE_OUTPUT_FILE}
exit 0
