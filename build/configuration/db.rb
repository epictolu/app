task :configure_db do
  configs = 
  {
    :db => 
    {
      :initial_catalog => delayed{configatron.project},
      :server_name => ENV['HOSTNAME'],
      :osql_connection_string => delayed{"-E \-S #{configatron.db.server_name}"},
      :web_account_sql => "#{configatron.db.web_user_account}, N'#{configatron.db.web_user_account}'",
      :app_connection => "data source=Server;Integrated Security=SSPI;Initial Catalog=blah"
    }
  }

  configatron.configure_from_hash configs
end

Rake::Task[:configure_db].invoke
