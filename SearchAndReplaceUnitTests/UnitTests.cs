using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchAndReplaceNS;

namespace SearchAndReplaceUnitTests
{
    [TestClass]
    public class SearchAndReplaceTests
    {
        [TestMethod]
        public void EmptyTextWithEmptyPattern()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "";
            String pattern = "";
            String replacement = "a";
            String expected = "";

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct. It should be " + expected);
        }

        [TestMethod]
        public void EmptyTextWithEmptyPatternAndEmptyReplacement()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "";
            String pattern = "";
            String replacement = "";
            String expected = "";

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct. It should be " + expected);
        }

        [TestMethod]
        public void EmptyTextWithNotEmptyPatternAndEmptyReplacement()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "";
            String pattern = "abc";
            String replacement = "";
            String expected = "";

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct");
        }

        [TestMethod]
        public void PatternEqualsToText()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "banana";
            String pattern = "banana";
            String replacement = "hello";
            String expected = replacement;

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct");
        }

        [TestMethod]
        public void PatternBiggerThanText()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "banana";
            String pattern = "bananas";
            String replacement = "hello";
            String expected = text.Replace(pattern, replacement);

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct");
        }

        [TestMethod]
        public void PatternSmallerThanText()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "banana";
            String pattern = "an";
            String replacement = "na";
            String expected = text.Replace(pattern, replacement);

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct");
        }

        [TestMethod]
        public void PatternDoesntExist()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "banana";
            String pattern = "hi";
            String replacement = "na";
            String expected = text.Replace(pattern, replacement);

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct");
        }

        [TestMethod]
        public void PatternEqualsToReplacement()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "banana";
            String pattern = "an";
            String replacement = pattern;
            String expected = text.Replace(pattern, replacement);

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct");
        }

        [TestMethod]
        public void EmptyPattern()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "banana";
            String pattern = "";
            String replacement = "hi";
            String expected = text;

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct");
        }

        [TestMethod]
        public void ExactlyOneReplacement()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "banana";
            String pattern = "anan";
            String replacement = "hi";
            String expected = text.Replace(pattern, replacement);

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct");
        }

        [TestMethod]
        public void ExactlyTwoConsecutiveReplacements()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "banana";
            String pattern = "an";
            String replacement = "hi";
            String expected = text.Replace(pattern, replacement);

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct");
        }

        [TestMethod]
        public void ExactlyTwoNonConsecutiveReplacements()
        {
            // arrange
            KnuttMorrisPratt kmp = new KnuttMorrisPratt();
            String text = "shloshomo";
            String pattern = "sh";
            String replacement = "hs";
            String expected = text.Replace(pattern, replacement);

            // act
            String new_str = kmp.replacePatternInString(text, pattern, replacement);

            // assert
            Assert.AreEqual(expected, new_str, "Replacement is not correct");
        }
    }
}
