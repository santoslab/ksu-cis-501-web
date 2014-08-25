cd src/main/rst
make clean
touch source/notes.rst
make html
scp -r build/html/* cislinux.cis.ksu.edu:~santos/web/softwarearch.santoslab.org/
cd ../../..
