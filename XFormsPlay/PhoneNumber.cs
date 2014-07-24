using System;
using System.Collections.Generic;
using System.Linq;

namespace XFormsPlay
{
	public class PhoneNumber
	{
		private static Dictionary<string,int> letterMapping;

		static PhoneNumber() {
			letterMapping = new Dictionary<string, int> ();
			letterMapping.Add ("ABC", 2);
			letterMapping.Add ("DEF", 3);
			letterMapping.Add ("GHI", 4);
			letterMapping.Add ("JKL", 5);
			letterMapping.Add ("MNO", 6);
			letterMapping.Add ("PQR", 7);
			letterMapping.Add ("STU", 8);
			letterMapping.Add ("WXYZ", 9);

		}
		string translate (string text)
		{
			if (string.IsNullOrWhiteSpace (text))
				return text;

			var output = "";
			foreach (char c in text) {					 
				if (Char.IsLetter (c)) {
					output += getNumberFor (c);
				} else {
					output += c;
				}
			}
			return output;
		}

		int getNumberFor(Char letter) {
			var upCaseLettter = letter.ToString ().ToUpper ();
			return letterMapping.First (X => X.Key.Contains (upCaseLettter)).Value;
		}

		public string Number {
			get;
			private set;
		}

		public static PhoneNumber from(string number) {
			return new PhoneNumber (number);
		}

		private PhoneNumber (string number)
		{
			this.Number = translate(number);
		}

		//replace with valid phone number regex
		public bool IsValid() {
			if (string.IsNullOrWhiteSpace(Number))
				return false;
			int numCount = this.Number.Where (x => Char.IsDigit (x)).Count ();
			if (numCount == 11) {
				return Number.StartsWith ("1");
			} else if (numCount == 10) {
				return !Number.StartsWith ("1");
			} else {
				return false;
			}
		}
	}
}

