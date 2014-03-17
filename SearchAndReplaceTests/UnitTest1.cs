using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAndReplaceNS;

namespace SearchAndReplaceTests
{
    [TestClass]
    public class SearchAndReplaceTests
    {
        [TestMethod]
        public void EmptyTextWithEmptyPattern()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "";
            String pattern = "";
            String replacement = "a";

            String expectedStr = "";
            int expectedNumber = 0;
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct. It should be " + expectedStr);
            Assert.AreEqual(expectedNumber, number, "Number is not correct. It should be " + expectedNumber);
        }


        [TestMethod]
        public void EmptyTextWithEmptyPatternAndEmptyReplacement()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "";
            String pattern = "";
            String replacement = "";

            String expectedStr = "";
            int expectedNumber = 0;
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct. It should be " + expectedStr);
            Assert.AreEqual(expectedNumber, number, "Number is not correct. It should be " + expectedNumber);
        }


        [TestMethod]
        public void EmptyTextWithNotEmptyPatternAndEmptyReplacement()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "";
            String pattern = "abc";
            String replacement = "";

            String expectedStr = "";
            int expectedNumber = 0;
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct");
            Assert.AreEqual(expectedNumber, number, "Number is not correct");

        }


        [TestMethod]
        public void PatternEqualsToText()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "banana";
            String pattern = "banana";
            String replacement = "hello";

            String expectedStr = replacement;
            int expectedNumber = 1;

            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct");
            Assert.AreEqual(expectedNumber, number, "Number is not correct");

        }

        
        [TestMethod]
        public void PatternBiggerThanText()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "banana";
            String pattern = "bananas";
            String replacement = "hello";
           
            String expectedStr = text.Replace(pattern, replacement);
            int expectedNumber = 0;
           
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct");
            Assert.AreEqual(expectedNumber, number, "Number is not correct");

        }

        [TestMethod]
        public void PatternSmallerThanText()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "banana";
            String pattern = "an";
            String replacement = "na";
            
            String expectedStr = text.Replace(pattern, replacement);
            int expectedNumber = 2;
           
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct");
            Assert.AreEqual(expectedNumber, number, "Number is not correct");

        }
    
        [TestMethod]
        public void PatternDoesntExist()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "banana";
            String pattern = "hi";
            String replacement = "na";
            
            String expectedStr = text.Replace(pattern, replacement);
            int expectedNumber = 0; 
           
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct");
            Assert.AreEqual(expectedNumber, number, "Number is not correct");

        }

        
        [TestMethod]
        public void PatternEqualsToReplacement()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "banana";
            String pattern = "an";
            String replacement = pattern;
            
            String expectedStr = text.Replace(pattern, replacement);
            int expectedNumber = 2;
           
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct");
            Assert.AreEqual(expectedNumber, number, "Number is not correct");

        }
        
        [TestMethod]
        public void EmptyPattern()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "banana";
            String pattern = "";
            String replacement = "hi";
            
            String expectedStr = text;
            int expectedNumber = 0;
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct");
            Assert.AreEqual(expectedNumber, number, "Number is not correct");

        }

        
        [TestMethod]
        public void ExactlyOneReplacement()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "banana";
            String pattern = "anan";
            String replacement = "hi";
           
            String expectedStr = text.Replace(pattern, replacement);
            int expectedNumber = 1;
            
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct");
            Assert.AreEqual(expectedNumber, number, "Replacement is not correct");
        }

        
        [TestMethod]
        public void ExactlyTwoConsecutiveReplacements()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "banana";
            String pattern = "an";
            String replacement = "hi";
            
            String expectedStr = text.Replace(pattern, replacement);
            int expectedNumber = 2;
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct");
            Assert.AreEqual(expectedNumber, number, "Number is not correct");

        }

        
        [TestMethod]
        public void ExactlyTwoNonConsecutiveReplacements()
        {
            // arrange
            SearchAndReplace sar = new SearchAndReplace();
            String text = "shloshomo";
            String pattern = "sh";
            String replacement = "hs";
            
            String expectedStr = text.Replace(pattern, replacement);
            int expectedNumber = 2;
            // act
            int number = sar.replacePatternInString(ref text, pattern, replacement);

            // assert
            Assert.AreEqual(expectedStr, text, "Replacement is not correct");
            Assert.AreEqual(expectedNumber, number, "Replacement is not correct");

        } 
    }
}
