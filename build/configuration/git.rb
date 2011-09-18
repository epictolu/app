configs ={
  :git => {
    :user => missing("user",__FILE__),
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'store'
  }
}
configatron.configure_from_hash(configs)
