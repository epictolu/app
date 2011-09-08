configs ={
  :git => {
    :remotes => potentially_change("remotes",__FILE__),
    :repo => missing("repo",__FILE__)
  }
}
configatron.configure_from_hash(configs)
