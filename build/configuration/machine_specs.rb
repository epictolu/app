task :configure_mspec do
  configs = 
  {
    :specs =>
    {
      :runner_options => ["-x","example"],
      :assemblies => dynamic{Dir.glob("#{configatron.artifacts_dir}/*specs.dll")},
      :dir => "artifacts/specs",
      :report_dir => "artifacts/specs/report",
      :tools_folder => "packages/Machine.Specifications.0.4.21.0/tools"
    }
  }
  configatron.configure_from_hash configs
end

Rake::Task['configure_mspec'].invoke


