task :configure_db do
  configs = 
  {
    :db => 
    {
      :server_name => ENV['HOSTNAME'],
      :osql_connection_string => delayed{"-E \-S #{configatron.db.server_name}"},
      :osql_exe => "osql",
      :database_provider => "System.Data.SqlClient",
      :app_connection => "data source=#{delayed{configatron.db.server_name}};Integrated Security=SSPI;Initial Catalog=#{delayed{configatron.db.initial_catalog}}",
      :osql_args_prior_to_file_name => "-b -i"
    }
  }

  configatron.configure_from_hash configs
end

Rake::Task[:configure_db].invoke
