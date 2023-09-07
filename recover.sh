# execute it in your git project
cat git.txt | while read blob; do
  echo $blob; git show $blob > ./recovery/$blob.txt
done
