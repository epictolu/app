def exit_if_on_the_master_branch
  status = `git status`

  if (/\* master/ =~ status)
    "You need to run this on a non master branch"
    exit
  end
end

def checkout(branch_name)
  `git checkout -b #{branch_name}`
  `git checkout #{branch_name}`
end

def exit_if_not_on_the_master_branch

  status = `git status`

  if (/\* master/ !~ status)
    "You need to run this on a master branch"
    exit
  end

end
