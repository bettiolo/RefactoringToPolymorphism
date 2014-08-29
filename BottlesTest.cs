using System;
using NUnit.Framework;

namespace Tests
{
	public class Bottles
	{
		public string Verse(int bottles, int bottles2 = -1)
		{
			var firstVerseLine = "{0} bottle{1} of beer on the wall, {2} bottle{1} of beer.\r\n";
;			var secondVerseLinePart1 = "Take {0} down and pass it around,";

			var remainingBottles = bottles - 1;
			var secondVerseLinePart2 = " {0} bottle{1} of beer on the wall.";

			var alternativeEndingVerse = "Go to the store and buy some more, 99 bottles of beer on the wall.";

			
			var verse = String.Format(firstVerseLine, 
				bottles == 0 ?  "No more" : bottles.ToString(), 
				bottles != 1 ? "s" : "",
				bottles == 0 ?  "no more" : bottles.ToString()
				);
			if (remainingBottles >= 0)
			{
				verse += String.Format(secondVerseLinePart1, remainingBottles == 0 ? "it" : "one");
				verse += String.Format(secondVerseLinePart2, remainingBottles == 0 ? "no more" : remainingBottles.ToString(), remainingBottles != 1 ? "s" : "");
			}
			else
			{
				verse += alternativeEndingVerse;
			}

			if (bottles2 >= 0)
			{
				verse += "\r\n\r\n" + Verse(bottles2);
			}
			return verse;
		}
	}

	[TestFixture]
	public class BottlesTest
	{
		private Bottles _bottles;

		[SetUp]
		public void SetUp()
		{
			_bottles = new Bottles();
		}

		[Test]
		public void first_verse()
		{
			const string expected = @"99 bottles of beer on the wall, 99 bottles of beer.
Take one down and pass it around, 98 bottles of beer on the wall.";
			Assert.That(expected, Is.EqualTo(_bottles.Verse(99)));
		}

		[Test]
		public void another_verse()
		{
			const string expected = @"89 bottles of beer on the wall, 89 bottles of beer.
Take one down and pass it around, 88 bottles of beer on the wall.";
			Assert.
	That(expected, Is.EqualTo(_bottles.Verse(89)));
		}
	[Test]
		public void verse_2()
		{
			const string expected = @"2 bottles of beer on the wall, 2 bottles of beer.
Take one down and pass it around, 1 bottle of beer on the wall.";
			Assert.That(expected, Is.EqualTo(_bottles.Verse(2)));
		}

		[Test]
		public void verse_1()
		{
			const string expected = @"1 bottle of beer on the wall, 1 bottle of beer.
Take it down and pass it around, no more bottles of beer on the wall.";
			Assert.That(expected, Is.EqualTo(_bottles.Verse(1)));
		}

		[Test]
		public void verse_0()
		{
			const string expected = @"No more bottles of beer on the wall, no more bottles of beer.
Go to the store and buy some more, 99 bottles of beer on the wall.";
			Assert.That(expected, Is.EqualTo(_bottles.Verse(0)));
		}

		[Test]
		public void a_couple_of_verses()
		{
			const string expected = @"99 bottles of beer on the wall, 99 bottles of beer.
Take one down and pass it around, 98 bottles of beer on the wall.

98 bottles of beer on the wall, 98 bottles of beer.
Take one down and pass it around, 97 bottles of beer on the wall.";
			Assert.That(expected, Is.EqualTo(_bottles.Verse(99,98)));
		}

		[Test]
		public void a_few_verses()
		{
			const string expected = @"2 bottles of beer on the wall, 2 bottles of beer.
Take one down and pass it around, 1 bottle of beer on the wall.

1 bottle of beer on the wall, 1 bottle of beer.
Take it down and pass it around, no more bottles of beer on the wall.

No more bottles of beer on the wall, no more bottles of beer.
Go to the store and buy some more, 99 bottles of beer on the wall.";
			Assert.That(expected, Is.EqualTo(_bottles.Verse(2, 0)));
		}
	}
}
