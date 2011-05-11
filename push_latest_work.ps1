function verify_on_master()
{
  $status = git status

  if ($status[0].endswith("master"))
  {
    "You need to run this on a non master branch"
    exit
  }
}

verify_on_master()
git add -A
git commit -m "Pushing new changes"
verify_on_master()
git push origin



