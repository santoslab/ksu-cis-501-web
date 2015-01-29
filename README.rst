Notes
#####

The compiler website uses the following tools/frameworks:

* `Sphinx <http://sphinx-doc.org>`__

* `Pygments <http://pygments.org>`__

* `Bootstrap <http://getbootstrap.com>`__

* `Bootswatch <http://bootswatch.com>`__

* `Sphinx Bootstrap Theme <https://github.com/ryan-roemer/sphinx-bootstrap-theme>`__

* (Optional) `MathJax <http://mathjax.org>`__ 



Setup: Sphinx, etc.
###################

1. Install pip, sphinx, and pygments; in OS X using Macports: 

   .. code-block:: bash
   
      sudo port install py34-pip py34-sphinx py34-pygments

            
2. Install pygments Github style:

   .. code-block:: bash
   
      sudo pip install pygments-style-github

3. Install sphinx_bootstrap_theme:

   .. code-block:: bash

      sudo pip install sphinx_bootstrap_theme      

Cleaning, Building, and Viewing
###############################

* To "clean" previously built website, execute the `clean.sh` script file

* To "build" the website, execute the `build.sh` script file

* To "build" and view the website, execute the `view.sh` script file

