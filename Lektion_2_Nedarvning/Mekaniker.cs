using System;
using System.Collections.Generic;
using System.Text;

public class Mekaniker : Medarbejder
{
	public int AarForSvendeProeve { get; set; }
	public double Timeloen { get; set; }

    public override string ToString()
    {
        return $"{base.ToString()}, År for Svendeprøve: {AarForSvendeProeve}, Timeløn: {Timeloen}";
    }
}
