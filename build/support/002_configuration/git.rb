configs ={
  :git => {
    :user => "20111205edmonton",
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'app' 
  }
}
configatron.configure_from_hash(configs)
