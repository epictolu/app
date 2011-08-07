config = 
{
  :course_name => missing("course_name",__FILE__),
  :project => missing("project",__FILE__),
  :target => "Debug",
  :source_dir => missing("source_dir",__FILE__),
  :app_dir => missing("app_dir",__FILE__),
  :all_references => UniqueFiles.new(Dir.glob("packages/**/*.{dll,exe}")).all_files,
  :artifacts_dir => "artifacts",
  :config_dir => "source/config",
  :app_dir => delayed{"source/#{configatron.project}"},
  :log_file_name => delayed{"#{configatron.project}_log.txt"},
  :log_level => "DEBUG"
}
configatron.configure_from_hash config
