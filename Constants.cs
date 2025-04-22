/*
 * Copyright (c) 2025, Craig Fawkes, Munster Technological University, Cork, Ireland
 * Author:
 *    Craig Fawkes <craig.fawkes@mycit.ie>,
 *     
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 */

using System;
namespace Valve_Calc;

public class Constants
{
    // Metric constants
    public readonly struct KvConstants
    {
        private static readonly double N1kPa = 0.1;
        private static readonly double N1Bar = 1.0;
        private static readonly double N2 = 0.0016;
        private static readonly double N4 = 0.0707;
        private static readonly double N5 = 0.0018;
        private static readonly double N6kPa = 3.16;
        private static readonly double N6Bar = 31.6;
        private static readonly double N7kPa = 4.82;
        private static readonly double N7Bar = 482.0;
        private static readonly double N8kPa = 1.1;
        private static readonly double N8Bar = 110.0;
        private static readonly double N9T0kPa = 24.6;
        private static readonly double N9T0Bar = 2460.0;
        private static readonly double N9T15kPa = 26.0;
        private static readonly double N9T15Bar = 2600.0;
        private static readonly double N18 = 0.865;
        private static readonly double N19 = 2.5;
        private static readonly double N22T0kPa = 17.3;
        private static readonly double N22T0Bar = 1730.0;
        private static readonly double N22T15kPa = 18.4;
        private static readonly double N22T15Bar = 1840.0;
        private static readonly double N23 = 19.1;
        private static readonly double N26 = 12800000.0;
        private static readonly double N27T0kPa = 0.775;
        private static readonly double N27T0Bar = 77.5; // This needs checking as there is a print error in the standard
        private static readonly double N31 = 21000.0;
        private static readonly double N32 = 140.0;

        public KvConstants()
        {
        }

        public static double PubN1kPa
        { get { return N1kPa; } }

        public static double PubN1Bar
        { get { return N1Bar; } }

        public static double PubN2
        { get { return N2; } }

        public static double PubN4
        { get { return N4; } }

        public static double PubN5
        { get { return N5; } }

        public static double PubN6kPa
        { get { return N6kPa; } }

        public static double PubN6Bar
        { get { return N6Bar; } }

        public static double PubN7kPa
        { get { return N7kPa; } }

        public static double PubN7Bar
        { get { return N7Bar; } }

        public static double PubN8kPa
        { get { return N8kPa; } }

        public static double PubN8Bar
        { get { return N8Bar; } }

        public static double PubN9T0kPa
        { get { return N9T0kPa; } }

        public static double PubN9T0Bar
        { get { return N9T0Bar; } }

        public static double PubN9T15kPa
        { get { return N9T15kPa; } }

        public static double PubN9T15Bar
        { get { return N9T15Bar; } }

        public static double PubN18
        { get { return N18; } }

        public static double PubN19
        { get { return N19; } }

        public static double PubN22T0kPa
        { get { return N22T0kPa; } }

        public static double PubN22T0Bar
        { get { return N22T0Bar; } }

        public static double PubN22T15kPa
        { get { return N22T15kPa; } }

        public static double PubN22T15Bar
        { get { return N22T15Bar; } }

        public static double PubN23
        { get { return N23; } }

        public static double PubN26
        { get { return N26; } }

        public static double PubN27T0kPa
        { get { return N27T0kPa; } }

        public static double PubN27T0Bar
        { get { return N27T0Bar; } }

        public static double PubN31
        { get { return N31; } }

        public static double PubN32
        { get { return N32; } }
    };

    // Imperial constants
    public readonly struct CvConstants
    {
        private static readonly double N1kPa = 0.0865;
        private static readonly double N1Bar = 0.865;
        private static readonly double N1PSIA = 1.0;
        private static readonly double N2mm = 0.00214;
        private static readonly double N2in = 890.0;
        private static readonly double N4m3 = 0.076;
        private static readonly double N4gpm = 17300.0;
        private static readonly double N4scfh = 2153.0;
        private static readonly double N5mm = 0.00241;
        private static readonly double N5in = 1000.0;
        private static readonly double N6kPa = 2.73;
        private static readonly double N6Bar = 27.3;
        private static readonly double N6PSIA = 63.3;
        private static readonly double N7kPa = 4.17;
        private static readonly double N7Bar = 417.0;
        private static readonly double N7PSIA = 1360.0;
        private static readonly double N8kPa = 0.948;
        private static readonly double N8Bar = 94.8;
        private static readonly double N8PSIA = 19.3;
        private static readonly double N9T0kPa = 21.2;
        private static readonly double N9T0Bar = 2120.0;
        private static readonly double N9T0PSIA = 6940.0;
        private static readonly double N9T15kPa = 22.5;
        private static readonly double N9T15Bar = 2250.0;
        private static readonly double N9T15PSIA = 7320.0;
        private static readonly double N18mm = 1.0;
        private static readonly double N18in = 645.0;
        private static readonly double N19mm = 2.3;
        private static readonly double N19in = 0.0906;
        private static readonly double N22T0kPa = 15.0;
        private static readonly double N22T0Bar = 1500.0;
        private static readonly double N22T0PSIA = 4920.0;
        private static readonly double N22T15kPa = 15.9;
        private static readonly double N22T15Bar = 1590.0;
        private static readonly double N22T15PSIA = 5200.0;
        private static readonly double N23in = 17.0;
        private static readonly double N23mm = 0.0263;
        private static readonly double N26in = 9000000;
        private static readonly double N26mm = 0.0000952;
        private static readonly double N27T0kPa = 0.67;
        private static readonly double N27T0Bar = 67.0;
        private static readonly double N27T0PSIA = 13.7;
        private static readonly double N31mm = 19000.0;
        private static readonly double N31in = 0.0837;
        private static readonly double N32mm = 127.0;
        private static readonly double N32in = 17.0;

        public CvConstants()
        {
        }

        public static double PubN1kPa
        { get { return N1kPa; } }

        public static double PubN1Bar
        { get { return N1Bar; } }

        public static double PubN1PSIA
        { get { return N1PSIA; } }

        public static double PubN2mm
        { get { return N2mm; } }

        public static double PubN2in
        { get { return N2in; } }

        public static double PubN4m3
        { get { return N4m3; } }

        public static double PubN4gpm
        { get { return N4gpm; } }

        public static double PubN4scfh
        { get { return N4scfh; } }

        public static double PubN5mm
        { get { return N5mm; } }

        public static double PubN5in
        { get { return N5in; } }

        public static double PubN6kPa
        { get { return N6kPa; } }

        public static double PubN6PSIA
        { get { return N6PSIA; } }

        public static double PubN6Bar
        { get { return N6Bar; } }

        public static double PubN7kPa
        { get { return N7kPa; } }

        public static double PubN7Bar
        { get { return N7Bar; } }

        public static double PubN7PSIA
        { get { return N7PSIA; } }

        public static double PubN8kPa
        { get { return N8kPa; } }

        public static double PubN8Bar
        { get { return N8Bar; } }

        public static double PubN8PSIA
        { get { return N8PSIA; } }

        public static double PubN9T0kPa
        { get { return N9T0kPa; } }

        public static double PubN9T0Bar
        { get { return N9T0Bar; } }

        public static double PubN9T0PSIA
        { get { return N9T0PSIA; } }

        public static double PubN9T15kPa
        { get { return N9T15kPa; } }

        public static double PubN9T15Bar
        { get { return N9T15Bar; } }

        public static double PubN9T15PSIA
        { get { return N9T15PSIA; } }

        public static double PubN18mm
        { get { return N18mm; } }

        public static double PubN18in
        { get { return N18in; } }

        public static double PubN19mm
        { get { return N19mm; } }

        public static double PubN19in
        { get { return N19in; } }

        public static double PubN22T0kPa
        { get { return N22T0kPa; } }

        public static double PubN22T0Bar
        { get { return N22T0Bar; } }

        public static double PubN22T0PSIA
        { get { return N22T0PSIA; } }

        public static double PubN22T15kPa
        { get { return N22T15kPa; } }

        public static double PubN22T15Bar
        { get { return N22T15Bar; } }

        public static double PubN22T15PSIA
        { get { return N22T15PSIA; } }

        public static double PubN23mm
        { get { return N23mm; } }

        public static double PubN23in
        { get { return N23in; } }

        public static double PubN26mm
        { get { return N26mm; } }

        public static double PubN26in
        { get { return N26in; } }

        public static double PubN27T0kPa
        { get { return N27T0kPa; } }

        public static double PubN27T0Bar
        { get { return N27T0Bar; } }

        public static double PubN27T0PSIA
        { get { return N27T0PSIA; } }

        public static double PubN31mm
        { get { return N31mm; } }

        public static double PubN31in
        { get { return N31in; } }

        public static double PubN32mm
        { get { return N32mm; } }

        public static double PubN32in
        { get { return N32in; } }
    };

    // Physical constants - Annex C
    public readonly struct Acetylene
    {
        private static readonly string Name = "Acetylene";
        private static readonly string Symbol = "C2H2";
        private static readonly double M = 26.04;
        private static readonly double Y = 1.3;
        private static readonly double Fy = 0.929;
        private static readonly double Pc = 6140.0;
        private static readonly double Tc = 309.0;

        public Acetylene() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Air
    {
        private static readonly string Name = "Air";
        private static readonly string Symbol = "-";
        private static readonly double M = 28.97;
        private static readonly double Y = 1.4;
        private static readonly double Fy = 1.0;
        private static readonly double Pc = 3771.0;
        private static readonly double Tc = 133.0;

        public Air() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Ammonia
    {
        private static readonly string Name = "Ammonia";
        private static readonly string Symbol = "NH3";
        private static readonly double M = 17.03;
        private static readonly double Y = 1.32;
        private static readonly double Fy = 0.943;
        private static readonly double Pc = 11400.0;
        private static readonly double Tc = 406.0;

        public Ammonia() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Argon
    {
        private static readonly string Name = "Argon";
        private static readonly string Symbol = "A";
        private static readonly double M = 39.948;
        private static readonly double Y = 1.67;
        private static readonly double Fy = 1.191;
        private static readonly double Pc = 4870.0;
        private static readonly double Tc = 151.0;

        public Argon() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Benzene
    {
        private static readonly string Name = "Benzene";
        private static readonly string Symbol = "C6H6";
        private static readonly double M = 78.11;
        private static readonly double Y = 1.12;
        private static readonly double Fy = 0.8;
        private static readonly double Pc = 4924.0;
        private static readonly double Tc = 562.0;

        public Benzene() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Isobutane
    {
        private static readonly string Name = "Isobutane";
        private static readonly string Symbol = "C4H9";
        private static readonly double M = 58.12;
        private static readonly double Y = 1.1;
        private static readonly double Fy = 0.784;
        private static readonly double Pc = 3638.0;
        private static readonly double Tc = 408.0;

        public Isobutane() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct n_Butane
    {
        private static readonly string Name = "n-Butane";
        private static readonly string Symbol = "C4H10";
        private static readonly double M = 58.12;
        private static readonly double Y = 1.11;
        private static readonly double Fy = 0.793;
        private static readonly double Pc = 3800.0;
        private static readonly double Tc = 425.0;

        public n_Butane() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Isobutylene
    {
        private static readonly string Name = "Isobutylene";
        private static readonly string Symbol = "C4H8";
        private static readonly double M = 56.11;
        private static readonly double Y = 1.11;
        private static readonly double Fy = 0.79;
        private static readonly double Pc = 4000.0;
        private static readonly double Tc = 418.0;

        public Isobutylene() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Carbon_dioxide
    {
        private static readonly string Name = "Carbon dioxide";
        private static readonly string Symbol = "CO2";
        private static readonly double M = 44.01;
        private static readonly double Y = 1.3;
        private static readonly double Fy = 0.929;
        private static readonly double Pc = 7387.0;
        private static readonly double Tc = 304.0;

        public Carbon_dioxide() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Carbon_monoxide
    {
        private static readonly string Name = "Carbon monoxide";
        private static readonly string Symbol = "CO";
        private static readonly double M = 28.01;
        private static readonly double Y = 1.4;
        private static readonly double Fy = 1.0;
        private static readonly double Pc = 3496.0;
        private static readonly double Tc = 133.0;

        public Carbon_monoxide() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Chlorine
    {
        private static readonly string Name = "Chlorine";
        private static readonly string Symbol = "Cl2";
        private static readonly double M = 70.906;
        private static readonly double Y = 1.31;
        private static readonly double Fy = 0.934;
        private static readonly double Pc = 7980.0;
        private static readonly double Tc = 417.0;

        public Chlorine() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Ethane
    {
        private static readonly string Name = "Ethane";
        private static readonly string Symbol = "C2H6";
        private static readonly double M = 30.07;
        private static readonly double Y = 1.22;
        private static readonly double Fy = 0.871;
        private static readonly double Pc = 4884.0;
        private static readonly double Tc = 305.0;

        public Ethane() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Ethylene
    {
        private static readonly string Name = "Ethylene";
        private static readonly string Symbol = "C2H4";
        private static readonly double M = 28.05;
        private static readonly double Y = 1.22;
        private static readonly double Fy = 0.871;
        private static readonly double Pc = 5040.0;
        private static readonly double Tc = 283.0;

        public Ethylene() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Fluorine
    {
        private static readonly string Name = "Fluorine";
        private static readonly string Symbol = "F2";
        private static readonly double M = 18.998;
        private static readonly double Y = 1.36;
        private static readonly double Fy = 0.97;
        private static readonly double Pc = 5215.0;
        private static readonly double Tc = 144.0;

        public Fluorine() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Freon_11
    {
        private static readonly string Name = "Freon 11 (trichloromonofluormethane)";
        private static readonly string Symbol = "CCl3F";
        private static readonly double M = 137.37;
        private static readonly double Y = 1.14;
        private static readonly double Fy = 0.811;
        private static readonly double Pc = 4409.0;
        private static readonly double Tc = 471.0;

        public Freon_11() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Freon_12
    {
        private static readonly string Name = "Freon 12 (dichlorodifluoromethane)";
        private static readonly string Symbol = "CCl2F2";
        private static readonly double M = 120.91;
        private static readonly double Y = 1.13;
        private static readonly double Fy = 0.807;
        private static readonly double Pc = 4114.0;
        private static readonly double Tc = 385.0;

        public Freon_12() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Freon_13
    {
        private static readonly string Name = "Freon 13 (chlorotrifluoromethane)";
        private static readonly string Symbol = "CClF";
        private static readonly double M = 104.46;
        private static readonly double Y = 1.14;
        private static readonly double Fy = 0.814;
        private static readonly double Pc = 3869.0;
        private static readonly double Tc = 302.0;

        public Freon_13() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Freon_22
    {
        private static readonly string Name = "Freon 22 (chlorodifluoromethane)";
        private static readonly string Symbol = "CHClF2";
        private static readonly double M = 80.47;
        private static readonly double Y = 1.18;
        private static readonly double Fy = 0.846;
        private static readonly double Pc = 4977.0;
        private static readonly double Tc = 369.0;

        public Freon_22() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Helium
    {
        private static readonly string Name = "Helium";
        private static readonly string Symbol = "He";
        private static readonly double M = 4.003;
        private static readonly double Y = 1.66;
        private static readonly double Fy = 1.186;
        private static readonly double Pc = 229.0;
        private static readonly double Tc = 5.25;

        public Helium() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct n_Heptane
    {
        private static readonly string Name = "n-Heptane";
        private static readonly string Symbol = "C7H16";
        private static readonly double M = 100.2;
        private static readonly double Y = 1.05;
        private static readonly double Fy = 0.75;
        private static readonly double Pc = 2736.0;
        private static readonly double Tc = 540.0;

        public n_Heptane() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Hydrogen
    {
        private static readonly string Name = "Hydrogen";
        private static readonly string Symbol = "H2";
        private static readonly double M = 2.016;
        private static readonly double Y = 1.41;
        private static readonly double Fy = 1.007;
        private static readonly double Pc = 1297;
        private static readonly double Tc = 33.25;

        public Hydrogen() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Hydrogen_chloride
    {
        private static readonly string Name = "Hydrogen chloride";
        private static readonly string Symbol = "HCl";
        private static readonly double M = 36.46;
        private static readonly double Y = 1.41;
        private static readonly double Fy = 1.007;
        private static readonly double Pc = 8319.0;
        private static readonly double Tc = 325.0;

        public Hydrogen_chloride() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Hydrogen_fluoride
    {
        private static readonly string Name = "Hydrogen fluoride";
        private static readonly string Symbol = "HF";
        private static readonly double M = 20.01;
        private static readonly double Y = 0.97;
        private static readonly double Fy = 0.691;
        private static readonly double Pc = 6485.0;
        private static readonly double Tc = 461.0;

        public Hydrogen_fluoride() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Methane
    {
        private static readonly string Name = "Methane";
        private static readonly string Symbol = "CH4";
        private static readonly double M = 16.04;
        private static readonly double Y = 1.32;
        private static readonly double Fy = 0.943;
        private static readonly double Pc = 4600.0;
        private static readonly double Tc = 191.0;

        public Methane() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Methyl_chloride
    {
        private static readonly string Name = "Methyl chloride";
        private static readonly string Symbol = "CH3Cl";
        private static readonly double M = 50.49;
        private static readonly double Y = 1.24;
        private static readonly double Fy = 0.889;
        private static readonly double Pc = 6677.0;
        private static readonly double Tc = 417.0;

        public Methyl_chloride() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Natural_gas
    {
        private static readonly string Name = "Natural gas";
        private static readonly string Symbol = "-";
        private static readonly double M = 17.74;
        private static readonly double Y = 1.27;
        private static readonly double Fy = 0.907;
        private static readonly double Pc = 4634.0;
        private static readonly double Tc = 203.0;

        public Natural_gas() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Neon
    {
        private static readonly string Name = "Neon";
        private static readonly string Symbol = "Ne";
        private static readonly double M = 20.179;
        private static readonly double Y = 1.64;
        private static readonly double Fy = 1.171;
        private static readonly double Pc = 2726.0;
        private static readonly double Tc = 44.45;

        public Neon() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Nitric_oxide
    {
        private static readonly string Name = "Nitric oxide";
        private static readonly string Symbol = "NO";
        private static readonly double M = 63.01;
        private static readonly double Y = 1.40;
        private static readonly double Fy = 1.0;
        private static readonly double Pc = 6485.0;
        private static readonly double Tc = 180.0;

        public Nitric_oxide() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Nitrogen
    {
        private static readonly string Name = "Nitrogen";
        private static readonly string Symbol = "N2";
        private static readonly double M = 28.013;
        private static readonly double Y = 1.40;
        private static readonly double Fy = 1.0;
        private static readonly double Pc = 3394.0;
        private static readonly double Tc = 126.0;

        public Nitrogen() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Octane
    {
        private static readonly string Name = "Octane";
        private static readonly string Symbol = "C8H18";
        private static readonly double M = 114.23;
        private static readonly double Y = 1.66;
        private static readonly double Fy = 1.186;
        private static readonly double Pc = 2513.0;
        private static readonly double Tc = 569.0;

        public Octane() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Oxygen
    {
        private static readonly string Name = "Oxygen";
        private static readonly string Symbol = "O2";
        private static readonly double M = 32.0;
        private static readonly double Y = 1.40;
        private static readonly double Fy = 1.0;
        private static readonly double Pc = 5040.0;
        private static readonly double Tc = 155.0;

        public Oxygen() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Pentane
    {
        private static readonly string Name = "Pentane";
        private static readonly string Symbol = "C5H12";
        private static readonly double M = 72.15;
        private static readonly double Y = 1.06;
        private static readonly double Fy = 0.757;
        private static readonly double Pc = 3374.0;
        private static readonly double Tc = 470.0;

        public Pentane() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Propane
    {
        private static readonly string Name = "Propane";
        private static readonly string Symbol = "C3H8";
        private static readonly double M = 44.10;
        private static readonly double Y = 1.15;
        private static readonly double Fy = 0.821;
        private static readonly double Pc = 4256.0;
        private static readonly double Tc = 370.0;

        public Propane() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Propylene
    {
        private static readonly string Name = "Propylene";
        private static readonly string Symbol = "C3H6";
        private static readonly double M = 42.08;
        private static readonly double Y = 1.14;
        private static readonly double Fy = 0.814;
        private static readonly double Pc = 4600.0;
        private static readonly double Tc = 365.0;

        public Propylene() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Saturated_steam
    {
        private static readonly string Name = "Saturated steam";
        private static readonly string Symbol = "-";
        private static readonly double M = 18.016;
        private static readonly double Y = 1.295; // Actual value 1.25 - 1.32, so median value used
        private static readonly double Fy = 0.918; // Actual value 0.893 - 0.943, so median value used
        private static readonly double Pc = 22119.0;
        private static readonly double Tc = 647.0;

        public Saturated_steam() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Sulphur_dioxide
    {
        private static readonly string Name = "Sulphur dioxide";
        private static readonly string Symbol = "SO2";
        private static readonly double M = 64.06;
        private static readonly double Y = 1.26;
        private static readonly double Fy = 0.9;
        private static readonly double Pc = 7822.0;
        private static readonly double Tc = 430.0;

        public Sulphur_dioxide() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    public readonly struct Superheated_steam
    {
        private static readonly string Name = "Superheated steam";
        private static readonly string Symbol = "-";
        private static readonly double M = 18.016;
        private static readonly double Y = 1.315;
        private static readonly double Fy = 0.939;
        private static readonly double Pc = 22119.0;
        private static readonly double Tc = 647.0;

        public Superheated_steam() { }

        public static string PubName
        { get { return Name; } }

        public static string PubSymbol
        { get { return Symbol; } }

        public static double PubM
        { get { return M; } }

        public static double PubY
        { get { return Y; } }

        public static double PubFy
        { get { return Fy; } }

        public static double PubPc
        { get { return Pc; } }

        public static double PubTc
        { get { return Tc; } }
    };

    /*
     * Typical values of valve style modifier Fd, liquid pressure recoveryactor FL,
     * and pressure differential ratio factor xT at full rated travel
     */
    public readonly struct GSP3Vportplug
    {
        private static readonly string Name = "3 V-port plug";
        private static readonly double Fl = 0.9;
        private static readonly double Xt = 0.7;
        private static readonly double Fd = 0.48;

        public GSP3Vportplug() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSP4Vportplug
    {
        private static readonly string Name = "4 V-port plug";
        private static readonly double Fl = 0.9;
        private static readonly double Xt = 0.7;
        private static readonly double Fd = 0.41;

        public GSP4Vportplug() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSP6Vportplug
    {
        private static readonly string Name = "6 V-port plug";
        private static readonly double Fl = 0.9;
        private static readonly double Xt = 0.7;
        private static readonly double Fd = 0.3;

        public GSP6Vportplug() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSPContouredplugOpen
    {
        private static readonly string Name = "Contoured plug (linear and equal percentage)";
        private static readonly double Fl = 0.9;
        private static readonly double Xt = 0.72;
        private static readonly double Fd = 0.46;

        public GSPContouredplugOpen() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSPContouredplugClose
    {
        private static readonly string Name = "Contoured plug (linear and equal percentage)";
        private static readonly double Fl = 0.8;
        private static readonly double Xt = 0.55;
        private static readonly double Fd = 1.0;

        public GSPContouredplugClose() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSP60EDDrilledCage
    {
        private static readonly string Name = "60 equal diameter hole drilled cage";
        private static readonly double Fl = 0.9;
        private static readonly double Xt = 0.68;
        private static readonly double Fd = 0.13;

        public GSP60EDDrilledCage() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSP120EDDrilledCage
    {
        private static readonly string Name = "120 equal diameter hole drilled cage";
        private static readonly double Fl = 0.9;
        private static readonly double Xt = 0.68;
        private static readonly double Fd = 0.09;

        public GSP120EDDrilledCage() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSPCharacterizedcageOut
    {
        private static readonly string Name = "Characterized cage, 4-port";
        private static readonly double Fl = 0.9;
        private static readonly double Xt = 0.75;
        private static readonly double Fd = 0.41;

        public GSPCharacterizedcageOut() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSPCharacterizedcageIn
    {
        private static readonly string Name = "Characterized cage, 4-port";
        private static readonly double Fl = 0.85;
        private static readonly double Xt = 0.7;
        private static readonly double Fd = 0.41;

        public GSPCharacterizedcageIn() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GDPPortedplug
    {
        private static readonly string Name = "Ported plug";
        private static readonly double Fl = 0.9;
        private static readonly double Xt = 0.75;
        private static readonly double Fd = 0.28;

        public GDPPortedplug() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GDPContouredplug
    {
        private static readonly string Name = "Contoured plug";
        private static readonly double Fl = 0.85;
        private static readonly double Xt = 0.7;
        private static readonly double Fd = 0.32;

        public GDPContouredplug() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GAContouredplugOpen
    {
        private static readonly string Name = "Contoured plug (linear and equal percentage)";
        private static readonly double Fl = 0.9;
        private static readonly double Xt = 0.72;
        private static readonly double Fd = 0.46;

        public GAContouredplugOpen() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GAContouredplugClose
    {
        private static readonly string Name = "Contoured plug (linear and equal percentage)";
        private static readonly double Fl = 0.8;
        private static readonly double Xt = 0.65;
        private static readonly double Fd = 1.0;

        public GAContouredplugClose() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GACharacterizedcageout
    {
        private static readonly string Name = "Characterized cage, 4-port";
        private static readonly double Fl = 0.9;
        private static readonly double Xt = 0.65;
        private static readonly double Fd = 0.41;

        public GACharacterizedcageout() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GACharacterizedcagein
    {
        private static readonly string Name = "Characterized cage, 4-port";
        private static readonly double Fl = 0.85;
        private static readonly double Xt = 0.6;
        private static readonly double Fd = 0.41;

        public GACharacterizedcagein() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GAVenturi
    {
        private static readonly string Name = "Venturi";
        private static readonly double Fl = 0.5;
        private static readonly double Xt = 0.2;
        private static readonly double Fd = 1.0;

        public GAVenturi() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSFTVnotch
    {
        private static readonly string Name = "V-notch";
        private static readonly double Fl = 0.98;
        private static readonly double Xt = 0.84;
        private static readonly double Fd = 0.7;

        public GSFTVnotch() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSFTFlatseat
    {
        private static readonly string Name = "Flat seat (short travel)";
        private static readonly double Fl = 0.85;
        private static readonly double Xt = 0.7;
        private static readonly double Fd = 0.3;

        public GSFTFlatseat() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct GSFTTaperedneedle
    {
        private static readonly string Name = "Tapered needle";
        private static readonly double Fl = 0.95;
        private static readonly double Xt = 0.84;
        private static readonly double Fd = 0.0;//Convert.ToDouble("N19*((CFl)^0.5)/Do");

        public GSFTTaperedneedle() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct ROTEccentricsphericalplugopen
    {
        private static readonly string Name = "Eccentric spherical plug";
        private static readonly double Fl = 0.85;
        private static readonly double Xt = 0.6;
        private static readonly double Fd = 0.42;

        public ROTEccentricsphericalplugopen() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct ROTEccentricsphericalplugclose
    {
        private static readonly string Name = "Eccentric spherical plug";
        private static readonly double Fl = 0.68;
        private static readonly double Xt = 0.4;
        private static readonly double Fd = 0.42;

        public ROTEccentricsphericalplugclose() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct ROTEccentricconicalplugopen
    {
        private static readonly string Name = "Eccentric conical plug";
        private static readonly double Fl = 0.77;
        private static readonly double Xt = 0.54;
        private static readonly double Fd = 0.44;

        public ROTEccentricconicalplugopen() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct ROTEccentricconicalplugclose
    {
        private static readonly string Name = "Eccentric conical plug";
        private static readonly double Fl = 0.79;
        private static readonly double Xt = 0.55;
        private static readonly double Fd = 0.44;

        public ROTEccentricconicalplugclose() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct BFLYSwingthrough70
    {
        private static readonly string Name = "Swing-through (70°)";
        private static readonly double Fl = 0.62;
        private static readonly double Xt = 0.35;
        private static readonly double Fd = 0.57;

        public BFLYSwingthrough70() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct BFLYSwingthrough60
    {
        private static readonly string Name = "Swing-through (60°)";
        private static readonly double Fl = 0.7;
        private static readonly double Xt = 0.42;
        private static readonly double Fd = 0.5;

        public BFLYSwingthrough60() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct BFLYFlutedvane70
    {
        private static readonly string Name = "Fluted vane (70°)";
        private static readonly double Fl = 0.67;
        private static readonly double Xt = 0.38;
        private static readonly double Fd = 0.3;

        public BFLYFlutedvane70() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct HPBFLYOffsetseat70
    {
        private static readonly string Name = "Offset seat (70°)";
        private static readonly double Fl = 0.67;
        private static readonly double Xt = 0.35;
        private static readonly double Fd = 0.57;

        public HPBFLYOffsetseat70() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct BALLFullbore70
    {
        private static readonly string Name = "Full bore (70°)";
        private static readonly double Fl = 0.74;
        private static readonly double Xt = 0.42;
        private static readonly double Fd = 0.99;

        public BALLFullbore70() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public readonly struct BALLSegmentedball
    {
        private static readonly string Name = "Segmented ball";
        private static readonly double Fl = 0.6;
        private static readonly double Xt = 0.3;
        private static readonly double Fd = 0.98;

        public BALLSegmentedball() { }

        public static string PubName
        { get { return Name; } }

        public static double PubFl
        { get { return Fl; } }

        public static double PubXt
        { get { return Xt; } }

        public static double PubFd
        { get { return Fd; } }
    };

    public Constants()
    {
    }
}
