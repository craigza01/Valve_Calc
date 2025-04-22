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
using System.ComponentModel;

namespace Valve_Calc;

public class Data_Set
{
    /*
     *  Create an Eumerator to hold flow coefficient types.       
     */
    public enum FlowCoefficientTypes
    {
        [Description("Kv")] Kv = 1,
        [Description("Cv")] Cv = 2
    };

    /*
     *  Create an Eumerator to hold pressure SI units.       
     */
    public enum PressureUnits
    {
        [Description("kPa")] kPa = 1,
        [Description("bar")] bar = 2,
        [Description("psia")] psia = 3
    };

    public enum FlowUnits
    {
        [Description("m3/h")] m3h = 1,
        [Description("gpm")] gpm = 2,
        [Description("scfh")] scfh = 3
    };

    public enum SizeUnits
    {
        [Description("mm")] mm = 1,
        [Description("in")] inch = 2
    };

    /*
     *  Create an Eumerator to hold medium types.       
     */
    public enum MediumTypes
    {
        [Description("Compressible fluids")] Compressible_fluids = 1,
        [Description("Incompressible fluids")] Incompressible_fluids = 2
    };


    /*
     *  Create an Eumerator to hold the different valve types.       
     */
    public enum ValveTypes
    {
        [Description("Globe, single port")] vtGSP = 1,
        [Description("Globe, double port")] vtGDP = 2,
        [Description("Globe, angle")] vtGA = 3,
        [Description("Globe, small flow trim")] vtGSFT = 4,
        [Description("Rotary")] vtROT = 5,
        [Description("Butterfly (centered shaft)")] vtBFLY = 6,
        [Description("High Performance Butterfly")] vtHPBFLY = 7,
        [Description("Ball")] vtBall = 8
    };

    /*
     *  Create enumerators for the different trim types for each valve
     */
    public enum GlobeSPTrimTypes
    {
        [Description("3 V-port plug")] gsptt3V = 1,
        //[Description(Constants.GSP3Vportplug.Name.ToString())] gsptt3V = 1,
        [Description("4 V-port plug")] gsptt4V = 2,
        [Description("6 V-port plug")] gsptt6V = 3,
        [Description("Contoured plug (linear & =%)")] gspttCP = 4,
        [Description("60 equal diameter hole drilled cage")] gsptt60D = 5,
        [Description("120 equal diameter hole drilled cage")] gsptt120D = 6,
        [Description("Characterized cage, 4-port")] gspttCC = 7
    };

    public enum GlobeDPTrimTypes
    {
        [Description("Ported plug")] gdpttPP = 1,
        [Description("Contoured plug")] gdpttCP = 2
    };

    public enum GlobeATrimTypes
    {
        [Description("Contoured plug (linear & =%)")] gattCP = 1,
        [Description("Characterized cage, 4-port")] gattCC = 2,
        [Description("Venturi")] gattV = 3
    };

    public enum GlobeSFTrimTypes
    {
        [Description("V-notch")] gsfttVN = 1,
        [Description("Flat seat (short travel)")] gsfttFS = 2,
        [Description("Tapered needle")] gsfttTN = 3
    };

    public enum RotaryTrimTypes
    {
        [Description("Eccentric spherical plug")] rotttSP = 1,
        [Description("Eccentric conical plug")] rotttCP = 2
    };

    public enum ButterflyTrimTypes
    {
        [Description("Swing-through (70º)")] bflyttSS70 = 1,
        [Description("Swing-through (60º)")] bflyttSS60 = 2,
        [Description("Fluted vane (70º)")] bflyttFV = 3
    };

    public enum HighPerformanceButterflyTrimTypes
    {
        [Description("Offset seat (70º)")] hpbflyttOS = 1
    };

    public enum BallTrimTypes
    {
        [Description("Full bore (70º)")] bttFB = 1,
        [Description("Segmented ball")] bttSB = 2
    };

    public enum GasTypes
    {
        [Description("Acetylene")] C2H2 = 1,
        [Description("Air")] O = 2,
        [Description("Ammonia")] NH3 = 3,
        [Description("Argon")] A = 4,
        [Description("Benzene")] C6H6 = 5,
        [Description("Isobutane")] C4H9 = 6,
        [Description("n-Butane")] C4H10 = 7,
        [Description("Isobutylene")] C4H8 = 8,
        [Description("Carbon dioxide")] CO2 = 9,
        [Description("Carbon monoxide")] CO = 10,
        [Description("Chlorine")] Cl2 = 11,
        [Description("Ethane")] C2H6 = 12,
        [Description("Ethylene")] C2H4 = 13,
        [Description("Fluorine")] F2 = 14,
        [Description("Freon 11 (trichloromonofluormethane)")] CCl3F = 15,
        [Description("Freon 12 (dichlorodifluoromethane)")] CCl2F2 = 16,
        [Description("Freon 13 (chlorotrifluoromethane)")] CClF = 17,
        [Description("Freon 22 (chlorodifluoromethane)")] CHClF2 = 18,
        [Description("Helium")] He = 19,
        [Description("n-Heptane")] C7H16 = 20,
        [Description("Hydrogen")] H2 = 21,
        [Description("Hydrogen chloride")] HCl = 22,
        [Description("Hydrogen fluoride")] HF = 23,
        [Description("Methane")] CH4 = 24,
        [Description("Methyl chloride")] CH3Cl = 25,
        [Description("Natural gas")] NG = 26,
        [Description("Neon")] Ne = 27,
        [Description("Nitric oxide")] NO = 28,
        [Description("Nitrogen")] N2 = 29,
        [Description("Octane")] C8H18 = 30,
        [Description("Oxygen")] O2 = 31,
        [Description("Pentane")] C5H12 = 32,
        [Description("Propane")] C3H8 = 33,
        [Description("Propylene")] C3H6 = 34,
        [Description("Saturated steam")] SS = 35,
        [Description("Sulphur dioxide")] SO2 = 36,
        [Description("Superheated steam")] SHS = 37

    };



}
