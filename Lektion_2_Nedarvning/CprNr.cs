using System;
using System.Collections.Generic;
using System.Text;

public class CprNr
{
	public CprNr (string bDate, string sNumber)
	{
		BirthDate = bDate;
		SequenceNumber = sNumber;
	}

	public string BirthDate { get; set; }
	public string SequenceNumber { get; set; }

    public override string ToString()
    {
        return $"{BirthDate}-{SequenceNumber}";
    }
}