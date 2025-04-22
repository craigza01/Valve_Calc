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
using System.Security.Permissions;
using System.Windows.Media;

namespace Valve_Calc;

public static class Equations
{
    // Non-choked turbulent flow without attached fittings - liquid
    public static double Eq1C(double Q, double N1, double SG, double deltaP)
    {
        return ((Q / N1) * Math.Sqrt(SG / deltaP));
    }

    // Non-choked turbulent flow with attached fittings - liquid
    public static double Eq2C(double Q, double N1, double Fp, double SG, double deltaP)
    {
        return ((Q / (N1 * Fp)) * Math.Sqrt(SG / deltaP));
    }


    // Choked turbulent flow without attached fittings - liquid
    public static double Eq3C(double Q, double N1, double Fl, double SG, double InletPressure, double Ff, double Pv)
    {
        return ((Q / (N1 * Fl)) * Math.Sqrt(SG / (InletPressure - (Ff * Pv))));
    }

    // Choked turbulent flow with attached fittings - liquid
    public static double Eq4C(double Q, double N1, double Flp, double SG, double InletPressure, double Ff, double Pv)
    {
        return ((Q / (N1 * Flp)) * Math.Sqrt(SG / (InletPressure - (Ff * Pv))));
    }

    // Non-choked turbulent flow without attached fittings - gas
    public static double Eq6C(double massFlow, double N6, double Y, double X, double inletPressure, double density)
    {
        return massFlow / (N6 * Y * Math.Sqrt(X * inletPressure * density));
    }

    // Piping geometry factor FP
    public static double Eq20Fp(double sumZeta, double N2, double Ci, double valveSize)
    {
        return 1 / (Math.Sqrt((1 + ((sumZeta / N2) * Math.Pow(Ci / Math.Pow(valveSize, 2), 2)))));
    }

    // algebraic sum of all of the effective velocity head loss coefficients of all fittings attached to the control valve
    public static double Eq21SumZeta(double zeta1, double zeta2, double zetaB1, double zetaB2)
    {
        return zeta1 + zeta2 + zetaB1 - zetaB2;
    }

    // Equations for different inlet and outlet reducer/expanders
    public static double Eq22ZetaB(double lineSize, double valveSize)
    {
        return 1 - Math.Pow((valveSize - lineSize), 4);
    }

    // Inlet reducer Zeta
    public static double Eq23ZetaIn(double lineSize, double valveSize)
    {
        return 0.5 * Math.Pow((1 - Math.Pow((valveSize / lineSize), 2)), 2);
    }

    // Outlet expander Zeta
    public static double Eq24ZetaOut(double lineSize, double valveSize)
    {
        return 1.0 * Math.Pow((1 - Math.Pow((valveSize / lineSize), 2)), 2);
    }

    // Inlet and outlet reducer and expander the same size
    public static double Eq25ZetaEqual(double lineSize, double valveSize)
    {
        return 1.5 * Math.Pow((1 - Math.Pow((valveSize / lineSize), 2)), 2);
    }

    // Reynolds number
    public static double Eq28Rev(double Q, double N4, double Fd, double viscosity, double C, double Fl, double N2, double pipeId)
    {
        return ((N4 * Fd * Q) / (viscosity * Math.Sqrt(C * Fl))) *
            (Math.Pow(((Math.Pow(Fl, 2) * Math.Pow(C, 2)) / ((N2 * Math.Pow(pipeId, 4))) + 1), 0.25));
    }

    // Combined liquid pressure recovery factor and piping geometry factor with attached fittings
    public static double Eq30Flp(double Fl, double N2, double Zeta, double C, double valveSize)
    {
        return Fl / Math.Sqrt(1 + ((Math.Pow(Fl, 2) / N2) * Zeta * Math.Pow(C / Math.Pow(valveSize, 2), 2)));
    }

    // Liquid critical pressure ratio factor
    public static double Eq31Ff(double Pv, double Pc)
    {
        return 0.96 - (0.28 * Math.Sqrt(Pv / Pc));
    }

    // specific heat ratio γ
    public static double Eq32Y(double X, double Fy, double Xt)
    {
        return 1 - (X / (3 * Fy * Xt));
    }

    //Specific heat ratio factor Fγ
    public static double Eq34Fy(double y)
    {
        return y / 1.4;
    }

    // Annex F (informative) — Equations for Reynolds number factor, FR
    public static double EqF1aFr(double Fl, double n1, double Rev)
    {
        return 1 + ((0.33 * Math.Pow(Fl, 0.5)) / (Math.Pow(n1, 0.25)) * Math.Log10(Rev / 10000));
    }

    public static double EqF1bN1(double Ci, double N2, double valveSize)
    {
        return N2 / Math.Pow(Ci / Math.Pow(valveSize, 2), 2);
    }

    public static double EqF3aFr(double Fl, double n2, double Rev)
    {
        return 1 + ((0.33 * Math.Pow(Fl, 0.5)) / (Math.Pow(n2, 0.25)) * Math.Log10(Rev / 10000));
    }

    public static double EqF3bN2(double Ci, double N32, double valveSize)
    {
        return 1 + N32 * Math.Pow(Ci / Math.Pow(valveSize, 2), 2 / 3);
    }


}
