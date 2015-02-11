rm -fR target
mkdir target
cd target
git clone git@github.com:ksu-cis-501/gh-pages.git
rm -fR gh-pages/*
cd ../src/main/rst
make clean
touch source/index.rst
make html
cp -R build/html/* ../../../target/gh-pages/
cd ../../../target/gh-pages
echo "softwarearch.santoslab.org" > CNAME
git add --all
git commit -m 'Updated.'
git push
