   # Selenium automated tests
[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Project consists of 5 automated tests:
- ***Adding product to cart***
- ***Filling contact us form***
- ***Log in***
- ***Sign up***
- ***Placing order***

Initially tests were recorded with Katalon recorder and after fine corrected in editor (adding wait function etc.).
Tests were runned and 100% successful.
   [![N|Solid](https://i.postimg.cc/Yqm5J2KG/Screenshot-2023-01-17-215736.png)](https://nodesource.com/products/nsolid)

In order for the tests to depend as little as possible on locators, a separate class was created that contains only By objects, i.e. locators.

To run project you need to install nuget these packages in VS:
- NUnit
- NUnit.Analyzers
- NUnit3TestAdapter
- Selenium.Support
- Selenium.WebDriver
- Selenium.WebDriver.GeckoDriver
