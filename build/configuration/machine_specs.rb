configs = 
{
  :specs =>
  {
    :runner_options => ["-x","example"],
    :assemblies => dynamic{Dir.glob("#{configatron.artifacts_dir}/*specs.dll")},
    :dir => "artifacts/specs",
    :report_dir => "artifacts/specs/report",
    :tools_folder => File.join(Dir.glob("packages/Machine.Specifications.*").first,"tools")
  }
}
configatron.configure_from_hash configs


