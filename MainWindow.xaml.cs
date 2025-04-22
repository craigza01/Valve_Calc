/*
 * Copyright (c) 2025, Craig Fawkes, Munster Technological University, Cork, Ireland
 * Author:
 *    Craig Fawkes <craig.fawkes@mycit.ie>,
 *     
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 */


using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using static Valve_Calc.Data_Set;

namespace Valve_Calc;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private double checkHolder = 0;
    private double Ff = 0;
    private double Fy = 0;
    private double differentialPressure = 0;
    private double inletPressure = 0;
    private double outletPressure = 0;
    private double vaporPressure = 0;
    private double criticalPressure = 0;
    private double Fl = 0;
    private double Fd = 0;
    private double C = 0;
    private double Fp = 0;
    private double Flp = 0;
    private double Ci = 0;
    public double zeta1 = 0;
    public double zeta2 = 0;
    public double zetab1 = 0;
    public double zetab2 = 0;
    public double sumZeta = 0;
    private double flow = 0;
    private double SG = 0;
    private double viscosity = 0;
    private double linesize = 0;
    private double valvesize = 0;
    private double temperature = 0;
    private double reynoldsnumber = 0;
    private double Fr = 0;
    public double n1 = 0;
    public double n2 = 0;
    private double flowtype = 0;
    private double M = 0;
    private double Y = 0;
    private double Pc = 0;
    private double Tc = 0;
    private double X = 0;
    private double Xt = 0;


    private double N1 = 0;
    private double N2 = 0;
    private double N4 = 0;
    private double N5 = 0;
    private double N6 = 0;
    private double N7 = 0;
    private double N8 = 0;
    private double N90 = 0;
    private double N915 = 0;
    private double N18 = 0;
    private double N19 = 0;
    private double N220 = 0;
    private double N2215 = 0;
    public double N23 = 0;
    public double N26 = 0;
    private double N27 = 0;
    public double N31 = 0;
    private double N32 = 0;

    public MainWindow()
    {
        InitializeComponent();
        ddlValveType.Visibility = Visibility.Hidden;
        ddlValveTrim.Visibility = Visibility.Hidden;
        ddlFlowDirection.Visibility = Visibility.Hidden;
        ddlPressureUnit.Visibility = Visibility.Hidden;
        ddlSizeUnit.Visibility = Visibility.Hidden;
        ddlFlowUnit.Visibility = Visibility.Hidden;
        ddlSizeUnit.Visibility = Visibility.Hidden;
        ddlCompressibleMedium.Visibility = Visibility.Hidden;

        lblFl.Content = "";
        lblXt.Content = "";
        lblFd.Content = "";

        // Populate the various drop down lists from the Enums constructed for each type
        foreach (Data_Set.FlowCoefficientTypes ft in Enum.GetValues(typeof(Data_Set.FlowCoefficientTypes)))
        {
            var s = ft.GetType().GetField(ft.ToString());
            string coefficientType = "";
            if (s is not null)
            {
                if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    coefficientType = attribute.Description;
                }
                ddlFlowcoefficientC.Items.Add(coefficientType);
            }
        }

        // Remove Cv from drop down list - as not implemented at this stage
        ddlFlowcoefficientC.Items.RemoveAt(2);

        foreach (Data_Set.MediumTypes mt in Enum.GetValues(typeof(Data_Set.MediumTypes)))
        {
            var s = mt.GetType().GetField(mt.ToString());
            string mediumType = "";
            if (s is not null)
            {
                if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    mediumType = attribute.Description;
                }
                ddlMediumType.Items.Add(mediumType);
            }
        }

        // Remove compressible fluids from list
        ddlMediumType.Items.RemoveAt(1);

        foreach (Data_Set.ValveTypes vt in Enum.GetValues(typeof(Data_Set.ValveTypes)))
        {
            var s = vt.GetType().GetField(vt.ToString());
            string valveType = "";
            if (s is not null)
            {
                if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    valveType = attribute.Description;
                }
                ddlValveType.Items.Add(valveType);
            }
        }

        foreach (Data_Set.GasTypes gt in Enum.GetValues(typeof(Data_Set.GasTypes)))
        {
            var s = gt.GetType().GetField(gt.ToString());
            string gasType = "";
            if (s is not null)
            {
                if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    gasType = attribute.Description;
                }
                ddlCompressibleMedium.Items.Add(gasType);
            }
        }
    }

    private void ddlValveType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (lblFl is not null)
        {
            lblFl.Content = "";
            lblXt.Content = "";
            lblFd.Content = "";
        }

        if (ddlValveTrim != null)
        {
            ddlValveTrim.Items.Clear();
            ddlValveTrim.Items.Add("Valve Trim");
            ddlValveTrim.SelectedIndex = 0;
            ddlValveTrim.Visibility = Visibility.Visible;
        }

        switch (ddlValveType.SelectedIndex)
        {
            case (int)Data_Set.ValveTypes.vtGSP:
                foreach (Data_Set.GlobeSPTrimTypes tt in Enum.GetValues(typeof(Data_Set.GlobeSPTrimTypes)))
                {
                    var s = tt.GetType().GetField(tt.ToString());
                    string trimType = "";
                    if (s is not null)
                    {
                        if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                        {
                            trimType = attribute.Description;
                        }
                        ddlValveTrim?.Items.Add(trimType);
                    }
                }
                break;
            case (int)Data_Set.ValveTypes.vtGDP:
                foreach (Data_Set.GlobeDPTrimTypes tt in Enum.GetValues(typeof(Data_Set.GlobeDPTrimTypes)))
                {
                    var s = tt.GetType().GetField(tt.ToString());
                    string trimType = "";
                    if (s is not null)
                    {
                        if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                        {
                            trimType = attribute.Description;
                        }
                        ddlValveTrim?.Items.Add(trimType);
                    }
                }
                break;
            case (int)Data_Set.ValveTypes.vtGA:
                foreach (Data_Set.GlobeATrimTypes tt in Enum.GetValues(typeof(Data_Set.GlobeATrimTypes)))
                {
                    var s = tt.GetType().GetField(tt.ToString());
                    string trimType = "";
                    if (s is not null)
                    {
                        if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                        {
                            trimType = attribute.Description;
                        }
                        ddlValveTrim?.Items.Add(trimType);
                    }
                }
                break;
            case (int)Data_Set.ValveTypes.vtGSFT:
                foreach (Data_Set.GlobeSFTrimTypes tt in Enum.GetValues(typeof(Data_Set.GlobeSFTrimTypes)))
                {
                    var s = tt.GetType().GetField(tt.ToString());
                    string trimType = "";
                    if (s is not null)
                    {
                        if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                        {
                            trimType = attribute.Description;
                        }
                        ddlValveTrim?.Items.Add(trimType);
                    }
                }
                break;
            case (int)Data_Set.ValveTypes.vtROT:
                foreach (Data_Set.RotaryTrimTypes tt in Enum.GetValues(typeof(Data_Set.RotaryTrimTypes)))
                {
                    var s = tt.GetType().GetField(tt.ToString());
                    string trimType = "";
                    if (s is not null)
                    {
                        if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                        {
                            trimType = attribute.Description;
                        }
                        ddlValveTrim?.Items.Add(trimType);
                    }
                }
                break;
            case (int)Data_Set.ValveTypes.vtBFLY:
                foreach (Data_Set.ButterflyTrimTypes tt in Enum.GetValues(typeof(Data_Set.ButterflyTrimTypes)))
                {
                    var s = tt.GetType().GetField(tt.ToString());
                    string trimType = "";
                    if (s is not null)
                    {
                        if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                        {
                            trimType = attribute.Description;
                        }
                        ddlValveTrim?.Items.Add(trimType);
                    }
                }
                break;
            case (int)Data_Set.ValveTypes.vtHPBFLY:
                foreach (Data_Set.HighPerformanceButterflyTrimTypes tt in Enum.GetValues(typeof(Data_Set.HighPerformanceButterflyTrimTypes)))
                {
                    var s = tt.GetType().GetField(tt.ToString());
                    string trimType = "";
                    if (s is not null)
                    {
                        if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                        {
                            trimType = attribute.Description;
                        }
                        ddlValveTrim?.Items.Add(trimType);
                    }
                }
                break;
            case (int)Data_Set.ValveTypes.vtBall:
                foreach (Data_Set.BallTrimTypes tt in Enum.GetValues(typeof(Data_Set.BallTrimTypes)))
                {
                    var s = tt.GetType().GetField(tt.ToString());
                    string trimType = "";
                    if (s is not null)
                    {
                        if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                        {
                            trimType = attribute.Description;
                        }
                        ddlValveTrim?.Items.Add(trimType);
                    }
                }
                break;
            default:
                if (ddlValveTrim != null)
                {
                    ddlValveTrim.Items.Clear();
                    ddlValveTrim.Items.Add("Valve Trim");
                    ddlValveTrim.SelectedIndex = 0;
                    ddlValveTrim.Visibility = Visibility.Hidden;
                }

                if (ddlFlowDirection != null)
                {
                    ddlFlowDirection.Items.Clear();
                    ddlFlowDirection.Items.Add("Flow Direction");
                    ddlFlowDirection.SelectedIndex = 0;
                    ddlFlowDirection.Visibility = Visibility.Hidden;
                }
                break;
        }
    }

    private void ddlValveTrim_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ddlFlowDirection != null && ddlValveTrim.SelectedIndex > 0)
        {
            Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
            ddlFlowDirection.Visibility = Visibility.Visible;
        }

        if (ddlFlowDirection != null && ddlValveTrim.SelectedIndex == 0)
        {
            ddlFlowDirection.Visibility = Visibility.Hidden;
        }

        /*
         *  Add flow direction based on trim selection        
         */
        if (ddlValveTrim.SelectedItem is not null)
        {
            if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gsptt3V) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Open or close");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gsptt4V) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Open or close");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gsptt6V) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Open or close");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gspttCP) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Open");
                ddlFlowDirection.Items.Add("Close");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gsptt60D) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Outward or inward");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gsptt120D) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Outward or inward");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gspttCC) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Outward");
                ddlFlowDirection.Items.Add("Inward");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGDP) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeDPTrimTypes.gdpttPP) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Inlet between seats");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGDP) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeDPTrimTypes.gdpttCP) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Either direction");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGA) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeATrimTypes.gattCP) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Open");
                ddlFlowDirection.Items.Add("Close");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGA) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeATrimTypes.gattCC) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Outward");
                ddlFlowDirection.Items.Add("Inward");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGA) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeATrimTypes.gattV) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Close");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSFT) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSFTrimTypes.gsfttVN) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Open");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSFT) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSFTrimTypes.gsfttFS) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Close");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSFT) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSFTrimTypes.gsfttTN) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Open");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtROT) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.RotaryTrimTypes.rotttSP) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Open");
                ddlFlowDirection.Items.Add("Close");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtROT) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.RotaryTrimTypes.rotttCP) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Open");
                ddlFlowDirection.Items.Add("Close");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtBFLY) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ButterflyTrimTypes.bflyttSS70) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Either");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtBFLY) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ButterflyTrimTypes.bflyttSS60) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Either");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtBFLY) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ButterflyTrimTypes.bflyttFV) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Either");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtHPBFLY) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.HighPerformanceButterflyTrimTypes.hpbflyttOS) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Either");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtBall) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.BallTrimTypes.bttFB) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Either");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtBall) &&
                ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.BallTrimTypes.bttSB) &&
                ddlFlowDirection is not null)
            {
                Functions.ddlFlowDirectionInit(ddlFlowDirection, "Flow Direction");
                ddlFlowDirection.Items.Add("Either");
                ddlFlowDirection.Visibility = Visibility.Visible;
            }
            else
            {

            }
        }
    }

    private void ddlFlowDirection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gsptt3V) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GSP3Vportplug.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSP3Vportplug.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSP3Vportplug.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gsptt4V) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GSP4Vportplug.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSP4Vportplug.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSP4Vportplug.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gsptt6V) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GSP6Vportplug.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSP6Vportplug.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSP6Vportplug.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gspttCP) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GSPContouredplugOpen.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSPContouredplugOpen.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSPContouredplugOpen.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gspttCP) &&
            ddlFlowDirection.SelectedIndex == 2)
        {
            lblFl.Content = "Fl = " + Constants.GSPContouredplugClose.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSPContouredplugClose.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSPContouredplugClose.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gsptt60D) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GSP60EDDrilledCage.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSP60EDDrilledCage.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSP60EDDrilledCage.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gsptt120D) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GSP120EDDrilledCage.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSP120EDDrilledCage.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSP120EDDrilledCage.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gspttCC) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GSPCharacterizedcageOut.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSPCharacterizedcageOut.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSPCharacterizedcageOut.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSPTrimTypes.gspttCC) &&
            ddlFlowDirection.SelectedIndex == 2)
        {
            lblFl.Content = "Fl = " + Constants.GSPCharacterizedcageIn.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSPCharacterizedcageIn.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSPCharacterizedcageIn.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGDP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeDPTrimTypes.gdpttPP) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GDPPortedplug.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GDPPortedplug.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GDPPortedplug.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGDP) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeDPTrimTypes.gdpttCP) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GDPContouredplug.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GDPContouredplug.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GDPContouredplug.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGA) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeATrimTypes.gattCP) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GAContouredplugOpen.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GAContouredplugOpen.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GAContouredplugOpen.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGA) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeATrimTypes.gattCP) &&
            ddlFlowDirection.SelectedIndex == 2)
        {
            lblFl.Content = "Fl = " + Constants.GAContouredplugClose.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GAContouredplugClose.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GAContouredplugClose.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGA) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeATrimTypes.gattCC) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GACharacterizedcageout.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GACharacterizedcageout.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GACharacterizedcageout.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGA) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeATrimTypes.gattCC) &&
            ddlFlowDirection.SelectedIndex == 2)
        {
            lblFl.Content = "Fl = " + Constants.GACharacterizedcagein.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GACharacterizedcagein.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GACharacterizedcagein.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGA) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeATrimTypes.gattV) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GAVenturi.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GAVenturi.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GAVenturi.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSFT) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSFTrimTypes.gsfttVN) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GSFTVnotch.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSFTVnotch.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSFTVnotch.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSFT) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSFTrimTypes.gsfttFS) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GSFTFlatseat.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSFTFlatseat.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSFTFlatseat.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtGSFT) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GlobeSFTrimTypes.gsfttTN) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.GSFTTaperedneedle.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.GSFTTaperedneedle.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.GSFTTaperedneedle.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtROT) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.RotaryTrimTypes.rotttSP) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.ROTEccentricsphericalplugopen.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.ROTEccentricsphericalplugopen.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.ROTEccentricsphericalplugopen.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtROT) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.RotaryTrimTypes.rotttSP) &&
            ddlFlowDirection.SelectedIndex == 2)
        {
            lblFl.Content = "Fl = " + Constants.ROTEccentricsphericalplugclose.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.ROTEccentricsphericalplugclose.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.ROTEccentricsphericalplugclose.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtROT) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.RotaryTrimTypes.rotttCP) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.ROTEccentricconicalplugopen.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.ROTEccentricconicalplugopen.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.ROTEccentricconicalplugopen.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtROT) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.RotaryTrimTypes.rotttCP) &&
            ddlFlowDirection.SelectedIndex == 2)
        {
            lblFl.Content = "Fl = " + Constants.ROTEccentricconicalplugclose.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.ROTEccentricconicalplugclose.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.ROTEccentricconicalplugclose.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtBFLY) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ButterflyTrimTypes.bflyttSS70) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.BFLYSwingthrough70.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.BFLYSwingthrough70.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.BFLYSwingthrough70.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtBFLY) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ButterflyTrimTypes.bflyttSS60) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.BFLYSwingthrough60.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.BFLYSwingthrough60.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.BFLYSwingthrough60.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtBFLY) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ButterflyTrimTypes.bflyttFV) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.BFLYFlutedvane70.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.BFLYFlutedvane70.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.BFLYFlutedvane70.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtHPBFLY) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.HighPerformanceButterflyTrimTypes.hpbflyttOS) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.HPBFLYOffsetseat70.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.HPBFLYOffsetseat70.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.HPBFLYOffsetseat70.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtBall) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.BallTrimTypes.bttFB) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.BALLFullbore70.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.BALLFullbore70.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.BALLFullbore70.PubFd.ToString();
        }
        else if (ddlValveType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.ValveTypes.vtBall) &&
            ddlValveTrim.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.BallTrimTypes.bttSB) &&
            ddlFlowDirection.SelectedIndex == 1)
        {
            lblFl.Content = "Fl = " + Constants.BALLSegmentedball.PubFl.ToString();
            lblXt.Content = "Xt = " + Constants.BALLSegmentedball.PubXt.ToString();
            lblFd.Content = "Fd = " + Constants.BALLSegmentedball.PubFd.ToString();
        }
        else
        {

        }
    }

    private void ddlMediumType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ddlValveType is not null)
        {
            if (ddlMediumType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.MediumTypes.Incompressible_fluids))
            {
                ddlCompressibleMedium.Visibility = Visibility.Hidden;
                tbMedium.Visibility = Visibility.Visible;
            }
            else if (ddlMediumType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.MediumTypes.Compressible_fluids))
            {
                ddlCompressibleMedium.Visibility = Visibility.Visible;
                ddlCompressibleMedium.SelectedIndex = 0;
                tbMedium.Visibility = Visibility.Hidden;
            }
            if (ddlMediumType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.MediumTypes.Incompressible_fluids) ||
                ddlMediumType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.MediumTypes.Compressible_fluids))
            {
                ddlValveType.Visibility = Visibility.Visible;
                ddlValveType.SelectedIndex = 0;
                ddlValveTrim.Visibility = Visibility.Hidden;
                ddlFlowDirection.Visibility = Visibility.Hidden;
            }
            else
            {
                ddlValveType.Visibility = Visibility.Hidden;
                ddlValveTrim.Visibility = Visibility.Hidden;
                ddlFlowDirection.Visibility = Visibility.Hidden;

                lblFl.Content = "";
                lblXt.Content = "";
                lblFd.Content = "";
            }
        }
    }

    private void ddlFlowcoefficientC_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (ddlFlowcoefficientC.SelectedIndex)
        {
            case (int)Data_Set.FlowCoefficientTypes.Kv:
                lblSGSI.Content = "";
                lblInletPressureSI.Content = "";
                lblOutletPressureSI.Content = "";
                lblDiffPressureSI.Content = "";
                lblTemperatureSI.Content = "";
                lblFlowRateSI.Content = "";
                lblNominalValveSizeSI.Content = "";
                lblPipeIDSI.Content = "";
                lblVaporPressureSI.Content = "";
                lblCriticalPressureSI.Content = "";
                lblViscositySI.Content = "";
                tbSG.Text = "";
                tbInletPressure.Text = "";
                tbOutletPressure.Text = "";
                lblDifferentialPressure.Content = "";
                tbTemperature.Text = "";
                tbFlowRate.Text = "";
                tbNominalValveSize.Text = "";
                tbPipeID.Text = "";
                tbVaporPressure.Text = "";
                tbCriticalPressure.Text = "";
                tbViscosity.Text = "";

                ddlPressureUnit.Items.Clear();
                ddlPressureUnit.Items.Add("Pressure Units");
                foreach (Data_Set.PressureUnits pu in Enum.GetValues(typeof(Data_Set.PressureUnits)))
                {
                    var s = pu.GetType().GetField(pu.ToString());
                    string pressureUnit = "";
                    if (s is not null)
                    {
                        if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                        {
                            pressureUnit = attribute.Description;
                        }
                        ddlPressureUnit.Items.Add(pressureUnit);
                    }
                }
                ddlPressureUnit.Items.RemoveAt(3);
                ddlPressureUnit.SelectedIndex = 0;
                ddlPressureUnit.Visibility = Visibility.Visible;

                lblLCPRF.Content = "";

                break;

            default:
                if (lblSGSI is not null)
                {
                    lblSGSI.Content = "";
                    lblInletPressureSI.Content = "";
                    lblOutletPressureSI.Content = "";
                    lblDiffPressureSI.Content = "";
                    lblTemperatureSI.Content = "";
                    lblFlowRateSI.Content = "";
                    lblNominalValveSizeSI.Content = "";
                    lblPipeIDSI.Content = "";
                    lblVaporPressureSI.Content = "";
                    lblCriticalPressureSI.Content = "";
                    lblViscositySI.Content = "";
                    tbSG.Text = "";
                    tbInletPressure.Text = "";
                    tbOutletPressure.Text = "";
                    lblDifferentialPressure.Content = "";
                    tbTemperature.Text = "";
                    tbFlowRate.Text = "";
                    tbNominalValveSize.Text = "";
                    tbPipeID.Text = "";
                    tbVaporPressure.Text = "";
                    tbCriticalPressure.Text = "";
                    tbViscosity.Text = "";

                    ddlPressureUnit.Items.Clear();
                    ddlPressureUnit.Items.Add("Pressure Units");
                    foreach (Data_Set.PressureUnits pu in Enum.GetValues(typeof(Data_Set.PressureUnits)))
                    {
                        var s = pu.GetType().GetField(pu.ToString());
                        string pressureUnit = "";
                        if (s is not null)
                        {
                            if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                            {
                                pressureUnit = attribute.Description;
                            }
                            ddlPressureUnit.Items.Add(pressureUnit);
                        }
                    }
                    ddlPressureUnit.SelectedIndex = 0;
                    ddlPressureUnit.Visibility = Visibility.Hidden;
                    ddlSizeUnit.Visibility = Visibility.Hidden;

                    lblLCPRF.Content = "";
                }

                break;
        }
    }

    private void ddlPressureUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (ddlFlowcoefficientC.SelectedIndex)
        {
            case (int)Data_Set.FlowCoefficientTypes.Kv:
                if (ddlPressureUnit.SelectedItem is not null)
                {
                    if (ddlPressureUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.PressureUnits.kPa))
                    {
                        lblSGSI.Content = "kg/m3";
                        lblInletPressureSI.Content = "kPa";
                        lblOutletPressureSI.Content = "kPa";
                        lblDiffPressureSI.Content = "kPa";
                        lblTemperatureSI.Content = "K";
                        lblFlowRateSI.Content = "";
                        lblNominalValveSizeSI.Content = "";
                        lblPipeIDSI.Content = "";
                        lblVaporPressureSI.Content = "kPa";
                        lblCriticalPressureSI.Content = "kPa";
                        lblViscositySI.Content = "m2/s";

                        lblLCPRF.Content = "";

                        ddlFlowUnit.Items.Clear();
                        ddlFlowUnit.Items.Add("Flow Units");
                        foreach (Data_Set.FlowUnits fu in Enum.GetValues(typeof(Data_Set.FlowUnits)))
                        {
                            var s = fu.GetType().GetField(fu.ToString());
                            string flowUnit = "";
                            if (s is not null)
                            {
                                if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                                {
                                    flowUnit = attribute.Description;
                                }
                                ddlFlowUnit.Items.Add(flowUnit);
                            }
                        }
                        ddlFlowUnit.SelectedIndex = 0;
                        ddlFlowUnit.Items.RemoveAt(3);
                        ddlFlowUnit.Items.RemoveAt(2);
                        ddlFlowUnit.Visibility = Visibility.Visible;
                        ddlSizeUnit.Visibility = Visibility.Hidden;
                    }
                    else if (ddlPressureUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.PressureUnits.bar))
                    {
                        lblSGSI.Content = "kg/m3";
                        lblInletPressureSI.Content = "bar";
                        lblOutletPressureSI.Content = "bar";
                        lblDiffPressureSI.Content = "bar";
                        lblTemperatureSI.Content = "K";
                        lblFlowRateSI.Content = "";
                        lblNominalValveSizeSI.Content = "";
                        lblPipeIDSI.Content = "";
                        lblVaporPressureSI.Content = "bar";
                        lblCriticalPressureSI.Content = "bar";
                        lblViscositySI.Content = "m2/s";

                        lblLCPRF.Content = "";

                        ddlFlowUnit.Items.Clear();
                        ddlFlowUnit.Items.Add("Flow Units");
                        foreach (Data_Set.FlowUnits fu in Enum.GetValues(typeof(Data_Set.FlowUnits)))
                        {
                            var s = fu.GetType().GetField(fu.ToString());
                            string flowUnit = "";
                            if (s is not null)
                            {
                                if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                                {
                                    flowUnit = attribute.Description;
                                }
                                ddlFlowUnit.Items.Add(flowUnit);
                            }
                        }
                        ddlFlowUnit.SelectedIndex = 0;
                        ddlFlowUnit.Items.RemoveAt(3);
                        ddlFlowUnit.Items.RemoveAt(2);
                        ddlFlowUnit.Visibility = Visibility.Visible;
                        ddlSizeUnit.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        lblSGSI.Content = "";
                        lblInletPressureSI.Content = "";
                        lblOutletPressureSI.Content = "";
                        lblDiffPressureSI.Content = "";
                        lblTemperatureSI.Content = "";
                        lblFlowRateSI.Content = "";
                        lblNominalValveSizeSI.Content = "";
                        lblPipeIDSI.Content = "";
                        lblVaporPressureSI.Content = "";
                        lblCriticalPressureSI.Content = "";
                        lblViscositySI.Content = "";

                        lblLCPRF.Content = "";

                        ddlFlowUnit.Items.Clear();
                        ddlFlowUnit.Items.Add("Flow Units");
                        foreach (Data_Set.FlowUnits fu in Enum.GetValues(typeof(Data_Set.FlowUnits)))
                        {
                            var s = fu.GetType().GetField(fu.ToString());
                            string flowUnit = "";
                            if (s is not null)
                            {
                                if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                                {
                                    flowUnit = attribute.Description;
                                }
                                ddlFlowUnit.Items.Add(flowUnit);
                            }
                        }
                        ddlFlowUnit.SelectedIndex = 0;
                        ddlFlowUnit.Visibility = Visibility.Hidden;
                        ddlSizeUnit.Visibility = Visibility.Hidden;
                    }
                }
                break;

            default:
                if (lblSGSI is not null)
                {
                    lblSGSI.Content = "";
                    lblInletPressureSI.Content = "";
                    lblOutletPressureSI.Content = "";
                    lblDiffPressureSI.Content = "";
                    lblTemperatureSI.Content = "";
                    lblFlowRateSI.Content = "";
                    lblNominalValveSizeSI.Content = "";
                    lblPipeIDSI.Content = "";
                    lblVaporPressureSI.Content = "";
                    lblCriticalPressureSI.Content = "";
                    lblViscositySI.Content = "";

                    lblLCPRF.Content = "";

                    ddlFlowUnit.Items.Clear();
                    ddlFlowUnit.Items.Add("Flow Units");
                    foreach (Data_Set.FlowUnits fu in Enum.GetValues(typeof(Data_Set.FlowUnits)))
                    {
                        var s = fu.GetType().GetField(fu.ToString());
                        string flowUnit = "";
                        if (s is not null)
                        {
                            if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                            {
                                flowUnit = attribute.Description;
                            }
                            ddlFlowUnit.Items.Add(flowUnit);
                        }
                    }
                    ddlFlowUnit.SelectedIndex = 0;
                    ddlFlowUnit.Visibility = Visibility.Hidden;
                    ddlSizeUnit.Visibility = Visibility.Hidden;
                }
                break;
        }
    }

    private void ddlFlowUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (ddlFlowcoefficientC.SelectedIndex)
        {
            case (int)Data_Set.FlowCoefficientTypes.Kv:
                if (ddlFlowUnit.SelectedItem is not null)
                {
                    if (ddlFlowUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.FlowUnits.m3h))
                    {
                        lblFlowRateSI.Content = "m3/h";
                    }
                    else
                    {
                        lblFlowRateSI.Content = "";
                    }

                    ddlSizeUnit.Items.Clear();
                    ddlSizeUnit.Items.Add("Size Units");
                    foreach (Data_Set.SizeUnits su in Enum.GetValues(typeof(Data_Set.SizeUnits)))
                    {
                        var s = su.GetType().GetField(su.ToString());
                        string flowUnit = "";
                        if (s is not null)
                        {
                            if (Attribute.GetCustomAttribute(s, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                            {
                                flowUnit = attribute.Description;
                            }
                            ddlSizeUnit.Items.Add(flowUnit);
                        }
                    }
                    ddlSizeUnit.SelectedIndex = 0;
                    ddlSizeUnit.Items.RemoveAt(2);
                    ddlSizeUnit.Visibility = Visibility.Visible;
                }
                break;

            default:
                if (lblFlowRateSI is not null)
                {
                    lblFlowRateSI.Content = "";
                    ddlSizeUnit.Visibility = Visibility.Hidden;
                }
                break;
        }
    }

    private void ddlSizeUnit_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ddlSizeUnit.SelectedItem is not null)
        {
            if (ddlSizeUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.SizeUnits.mm))
            {
                lblNominalValveSizeSI.Content = "mm";
                lblPipeIDSI.Content = "mm";
            }
            else if (ddlSizeUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.SizeUnits.inch))
            {
                lblNominalValveSizeSI.Content = "in";
                lblPipeIDSI.Content = "in";
            }
            else
            {
                if (lblNominalValveSizeSI is not null)
                {
                    lblNominalValveSizeSI.Content = "";
                    lblPipeIDSI.Content = "";
                }
            }
        }
    }

    private void btnCalculate_Click(object sender, RoutedEventArgs e)
    {
        // Check all drop down selections made
        if (!(ddlFlowcoefficientC.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.FlowCoefficientTypes.Kv)
            && (ddlPressureUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.PressureUnits.kPa) ||
            ddlPressureUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.PressureUnits.bar))
            && ddlFlowUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.FlowUnits.m3h)
            && ddlSizeUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.SizeUnits.mm)))
        {
            MessageBox.Show("Please select all SI drop down fields");
            return;
        }

        if (!(ddlMediumType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.MediumTypes.Incompressible_fluids)
            || ddlMediumType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.MediumTypes.Compressible_fluids)))
        {
            MessageBox.Show("Please select a fluid type");
            return;
        }

        if (ddlValveType.SelectedIndex == 0)
        {
            MessageBox.Show("Please select a valve type");
            return;
        }

        if (ddlValveTrim.SelectedIndex == 0)
        {
            MessageBox.Show("Please select a valve trim");
            return;
        }

        if (ddlFlowDirection.SelectedIndex == 0)
        {
            MessageBox.Show("Please select a flow direction");
            return;
        }

        double temp = 0;

        // Check that valid numbers are entered in the Critical and Vapor pressure text boxes
        bool canConvert = double.TryParse(tbVaporPressure.Text.ToString(), out checkHolder);

        if (canConvert == true)
        {
            vaporPressure = Convert.ToDouble(tbVaporPressure.Text);
            canConvert = double.TryParse(tbCriticalPressure.Text.ToString(), out checkHolder);
            if (canConvert == true)
            {
                criticalPressure = Convert.ToDouble(tbCriticalPressure.Text);
            }
            else
            {
                MessageBox.Show(string.Format("Invalid format critical pressure: {0}", tbCriticalPressure.Text));
                return;
            }
        }
        else
        {
            MessageBox.Show(string.Format("Invalid format vapour pressure: {0}", tbVaporPressure.Text));
            return;
        }

        // Check that valid numbers are entered in the Inlet and Outlet pressure text boxes
        canConvert = double.TryParse(tbInletPressure.Text.ToString(), out checkHolder);
        if (canConvert == true)
        {
            canConvert = double.TryParse(tbOutletPressure.Text.ToString(), out checkHolder);
            if (canConvert == true)
            {
                // Inlet, Outlet and Differential pressure
                inletPressure = Convert.ToDouble(tbInletPressure.Text);
                outletPressure = Convert.ToDouble(tbOutletPressure.Text);
                differentialPressure = inletPressure - outletPressure;
                lblDifferentialPressure.Content = differentialPressure.ToString();
            }
            else
            {
                MessageBox.Show(string.Format("Invalid format outlet pressure: {0}", tbOutletPressure.Text));
                return;
            }
        }
        else
        {
            MessageBox.Show(string.Format("Invalid format inlet pressure: {0}", tbInletPressure.Text));
            return;
        }

        // Get the Fl value from the label
        if (lblFl.Content is not null)
        {
            canConvert = double.TryParse(Functions.ExtractNumberUsingSpan(lblFl.Content.ToString()), out checkHolder);
            if (canConvert == true)
            {
                Fl = Convert.ToDouble(Functions.ExtractNumberUsingSpan(lblFl.Content.ToString()));
            }
            else
            {
                MessageBox.Show(string.Format("Invalid Fl: {0}", lblFl.Content));
                return;
            }
        }

        // Get the Fd value from the label
        if (lblFd.Content is not null)
        {
            canConvert = double.TryParse(Functions.ExtractNumberUsingSpan(lblFd.Content.ToString()), out checkHolder);
            if (canConvert == true)
            {
                Fd = Convert.ToDouble(Functions.ExtractNumberUsingSpan(lblFd.Content.ToString()));
            }
            else
            {
                MessageBox.Show(string.Format("Invalid Fd: {0}", lblFd.Content));
                return;
            }
        }

        // Get Xt value from label
        if (lblXt.Content is not null)
        {
            canConvert = double.TryParse(Functions.ExtractNumberUsingSpan(lblXt.Content.ToString()), out checkHolder);
            if (canConvert == true)
            {
                Xt = Convert.ToDouble(Functions.ExtractNumberUsingSpan(lblXt.Content.ToString()));
            }
            else
            {
                MessageBox.Show(string.Format("Invalid Xt: {0}", lblXt.Content));
                return;
            }
        }

        // Check valid numbers are entered for flow and SG
        canConvert = double.TryParse(tbFlowRate.Text.ToString(), out checkHolder);
        if (canConvert == true)
        {
            canConvert = double.TryParse(tbSG.Text.ToString(), out checkHolder);
            if (canConvert == true)
            {
                // flow and SG
                flow = Convert.ToDouble(tbFlowRate.Text);
                SG = Convert.ToDouble(tbSG.Text);
            }
            else
            {
                MessageBox.Show(string.Format("Invalid format SG: {0}", tbSG.Text));
                return;
            }
        }
        else
        {
            MessageBox.Show(string.Format("Invalid format flow rate: {0}", tbFlowRate.Text));
            return;
        }

        // Check valid numbers entered for viscosity
        canConvert = double.TryParse(tbViscosity.Text.ToString(), out checkHolder);
        if (canConvert == true)
        {
            // viscosity
            viscosity = Convert.ToDouble(tbViscosity.Text);
        }
        else
        {
            MessageBox.Show(string.Format("Invalid format viscosity: {0}", tbViscosity.Text));
            return;
        }


        // Check valid numbers entered for temperature
        canConvert = double.TryParse(tbTemperature.Text.ToString(), out checkHolder);
        if (canConvert == true)
        {
            // temperature
            temperature = Convert.ToDouble(tbTemperature.Text);
        }
        else
        {
            MessageBox.Show(string.Format("Invalid format temperature: {0}", tbTemperature.Text));
            return;
        }

        // Check valid numbers entered for valve size
        canConvert = double.TryParse(tbNominalValveSize.Text.ToString(), out checkHolder);
        if (canConvert == true)
        {
            // valve size
            valvesize = Convert.ToDouble(tbNominalValveSize.Text);
        }
        else
        {
            MessageBox.Show(string.Format("Invalid format valve size: {0}", tbNominalValveSize.Text));
            return;
        }

        // Check valid numbers entered for line size
        canConvert = double.TryParse(tbPipeID.Text.ToString(), out checkHolder);
        if (canConvert == true)
        {
            // line size
            linesize = Convert.ToDouble(tbPipeID.Text);
        }
        else
        {
            MessageBox.Show(string.Format("Invalid format line size: {0}", tbPipeID.Text));
            return;
        }

        // Set numerical constants N for kPa or bar
        if (ddlFlowcoefficientC.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.FlowCoefficientTypes.Kv)
            && ddlPressureUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.PressureUnits.kPa)
            && ddlFlowUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.FlowUnits.m3h)
            && ddlSizeUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.SizeUnits.mm))
        {
            N1 = Constants.KvConstants.PubN1kPa;
            N2 = Constants.KvConstants.PubN2;

            N4 = Constants.KvConstants.PubN4;
            N5 = Constants.KvConstants.PubN5;
            N6 = Constants.KvConstants.PubN6kPa;
            N7 = Constants.KvConstants.PubN7kPa;
            N8 = Constants.KvConstants.PubN8kPa;

            N18 = Constants.KvConstants.PubN18;
            N19 = Constants.KvConstants.PubN19;

            N23 = Constants.KvConstants.PubN23;

            N26 = Constants.KvConstants.PubN26;
            N27 = Constants.KvConstants.PubN27T0kPa;

            N31 = Constants.KvConstants.PubN31;
            N32 = Constants.KvConstants.PubN32;
        }
        else if (ddlFlowcoefficientC.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.FlowCoefficientTypes.Kv)
            && ddlPressureUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.PressureUnits.bar)
            && ddlFlowUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.FlowUnits.m3h)
            && ddlSizeUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.SizeUnits.mm))
        {
            N1 = Constants.KvConstants.PubN1Bar;
            N2 = Constants.KvConstants.PubN2;

            N4 = Constants.KvConstants.PubN4;
            N5 = Constants.KvConstants.PubN5;
            N6 = Constants.KvConstants.PubN6Bar;
            N7 = Constants.KvConstants.PubN7Bar;
            N8 = Constants.KvConstants.PubN8Bar;

            N18 = Constants.KvConstants.PubN18;
            N19 = Constants.KvConstants.PubN19;

            N23 = Constants.KvConstants.PubN23;

            N26 = Constants.KvConstants.PubN26;
            N27 = Constants.KvConstants.PubN27T0Bar;

            N31 = Constants.KvConstants.PubN31;
            N32 = Constants.KvConstants.PubN32;
        }


        // Incompressible fluids
        if (ddlMediumType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.MediumTypes.Incompressible_fluids))
        {
            // Liquid critical pressure ratio factor
            Ff = Equations.Eq31Ff(vaporPressure, criticalPressure);
            lblLCPRF.Content = "Liquid critical pressure ratio factor: " + Math.Round(Ff, 4, MidpointRounding.AwayFromZero);

            // Determine whether flow is chocked or not
            flowtype = (Math.Pow(Fl, 2) * (inletPressure - (Ff * vaporPressure)));

            // Check for Non-choked or Choked flow
            if (differentialPressure < flowtype)
            {
                lbldeltaPressure.Background = Brushes.White;
                lblDifferentialPressure.Background = Brushes.White;
                if (ddlPressureUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.PressureUnits.kPa))
                {
                    lbldeltaPressure.Content = "Non-choked flow: " + Math.Round(flowtype, 2, MidpointRounding.AwayFromZero) + "kPa";
                }
                else if (ddlPressureUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.PressureUnits.bar))
                {
                    lbldeltaPressure.Content = "Non-choked flow: " + Math.Round(flowtype, 2, MidpointRounding.AwayFromZero) + "bar";
                }

                C = Equations.Eq1C(flow, N1, SG, differentialPressure);
                reynoldsnumber = Equations.Eq28Rev(flow, N4, Fd, viscosity, C, Fl, N2, linesize);
                temp = Math.Round(reynoldsnumber, 2, MidpointRounding.AwayFromZero);
                lblReynolds.Content = "Reynolds number: " + temp.ToString("#,##0");

                // Turbulant flow
                if (reynoldsnumber > 10000)
                {
                    // Line size and valve size are the same
                    if (linesize == valvesize)
                    {
                        lblflowCoefficient.Content = "Kv = " + Math.Round(C, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        Fp = 1;
                        Ci = C;

                        zetab1 = Equations.Eq22ZetaB(linesize, valvesize);
                        zetab2 = Equations.Eq22ZetaB(linesize, valvesize);
                        zeta1 = Equations.Eq23ZetaIn(linesize, valvesize);
                        zeta2 = Equations.Eq24ZetaOut(linesize, valvesize);
                        sumZeta = Equations.Eq21SumZeta(zeta1, zeta2, zetab1, zetab2);

                        do
                        {
                            Fp = Equations.Eq20Fp(sumZeta, N2, Ci, valvesize);
                            Flp = Equations.Eq30Flp(Fl, N2, sumZeta, Ci, valvesize);

                            temp = Math.Pow((Flp / Fp), 2) * (inletPressure - (Ff * vaporPressure));

                            if (differentialPressure >= temp)
                            {
                                C = Equations.Eq4C(flow, N1, Flp, SG, inletPressure, Ff, vaporPressure);
                            }
                            else
                            {
                                C = Equations.Eq2C(flow, N1, Fp, SG, differentialPressure);
                            }

                            Ci = C;
                        } while (Ci / C < 0.99);

                        lblflowCoefficient.Content = "Kv = " + Math.Round(C, 2, MidpointRounding.AwayFromZero);
                    }
                }
                else
                {
                    Ci = 1.3 * C;
                    reynoldsnumber = Equations.Eq28Rev(flow, N4, Fd, viscosity, C, Fl, N2, linesize);

                    temp = C / Math.Pow(valvesize, 2);

                    if (ddlSizeUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.SizeUnits.mm))
                    {
                        if (temp > 0.016 * Constants.KvConstants.PubN18)
                        {
                            do
                            {
                                n1 = Equations.EqF1bN1(Ci, Constants.KvConstants.PubN2, valvesize);
                                Fr = Equations.EqF1aFr(Fl, n1, reynoldsnumber);
                                Ci = Ci * 1.3;
                            } while (C / Fr >= Ci);
                            lblflowCoefficient.Content = "Kv = " + Math.Round(Ci, 4, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            do
                            {
                                n2 = Equations.EqF3bN2(Ci, Constants.KvConstants.PubN32, valvesize);
                                Fr = Equations.EqF3aFr(Fl, n2, reynoldsnumber);
                                Ci = Ci * 1.3;
                            } while (C / Fr >= Ci);
                            lblflowCoefficient.Content = "Kv = " + Math.Round(Ci, 4, MidpointRounding.AwayFromZero);
                        }
                    }
                }
            }
            else
            {
                lbldeltaPressure.Background = Brushes.Yellow;
                lblDifferentialPressure.Background = Brushes.Yellow;

                if (ddlPressureUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.PressureUnits.kPa))
                {
                    lbldeltaPressure.Content = "Choked flow: " + Math.Round(flowtype, 2, MidpointRounding.AwayFromZero) + "kPa";
                }
                else if (ddlPressureUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.PressureUnits.bar))
                {
                    lbldeltaPressure.Content = "Choked flow: " + Math.Round(flowtype, 2, MidpointRounding.AwayFromZero) + "bar";
                }

                C = Equations.Eq3C(flow, N1, Fl, SG, inletPressure, Ff, vaporPressure);
                reynoldsnumber = Equations.Eq28Rev(flow, N4, Fd, viscosity, C, Fl, N2, linesize);
                temp = Math.Round(reynoldsnumber, 2, MidpointRounding.AwayFromZero);
                lblReynolds.Content = "Reynolds number: " + temp.ToString("#,##0");

                // Turbulant flow
                if (reynoldsnumber > 10000)
                {
                    // Line size and valve size are the same
                    if (linesize == valvesize)
                    {
                        lblflowCoefficient.Content = "Kv = " + Math.Round(C, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        Fp = 1;
                        Ci = C;

                        zetab1 = Equations.Eq22ZetaB(linesize, valvesize);
                        zetab2 = Equations.Eq22ZetaB(linesize, valvesize);
                        zeta1 = Equations.Eq23ZetaIn(linesize, valvesize);
                        zeta2 = Equations.Eq24ZetaOut(linesize, valvesize);
                        sumZeta = Equations.Eq21SumZeta(zeta1, zeta2, zetab1, zetab2);

                        do
                        {
                            Fp = Equations.Eq20Fp(sumZeta, N2, Ci, valvesize);
                            Flp = Equations.Eq30Flp(Fl, N2, sumZeta, Ci, valvesize);

                            temp = Math.Pow((Flp / Fp), 2) * (inletPressure - (Ff * vaporPressure));

                            if (differentialPressure >= temp)
                            {
                                C = Equations.Eq4C(flow, N1, Flp, SG, inletPressure, Ff, vaporPressure);
                            }
                            else
                            {
                                C = Equations.Eq2C(flow, N1, Fp, SG, differentialPressure);
                            }

                            Ci = C;
                        } while (Ci / C < 0.99);

                        lblflowCoefficient.Content = "Kv = " + Math.Round(C, 2, MidpointRounding.AwayFromZero);
                    }
                }
                else
                {
                    Ci = 1.3 * C;
                    reynoldsnumber = Equations.Eq28Rev(flow, N4, Fd, viscosity, C, Fl, N2, linesize);

                    temp = C / Math.Pow(valvesize, 2);

                    if (ddlSizeUnit.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.SizeUnits.mm))
                    {
                        if (temp > 0.016 * Constants.KvConstants.PubN18)
                        {
                            do
                            {
                                n1 = Equations.EqF1bN1(Ci, Constants.KvConstants.PubN2, valvesize);
                                Fr = Equations.EqF1aFr(Fl, n1, reynoldsnumber);
                                Ci = Ci * 1.3;
                            } while (C / Fr >= Ci);
                            lblflowCoefficient.Content = "Kv = " + Math.Round(Ci, 4, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            do
                            {
                                n2 = Equations.EqF3bN2(Ci, Constants.KvConstants.PubN32, valvesize);
                                Fr = Equations.EqF3aFr(Fl, n2, reynoldsnumber);
                                Ci = Ci * 1.3;
                            } while (C / Fr >= Ci);
                            lblflowCoefficient.Content = "Kv = " + Math.Round(Ci, 4, MidpointRounding.AwayFromZero);
                        }
                    }
                }
            }
        }
        else if (ddlMediumType.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.MediumTypes.Compressible_fluids))
        {
            if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C2H2))
            {
                M = Constants.Acetylene.PubM;
                Y = Constants.Acetylene.PubY;
                Pc = Constants.Acetylene.PubPc;
                Tc = Constants.Acetylene.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.O))
            {
                M = Constants.Air.PubM;
                Y = Constants.Air.PubY;
                Pc = Constants.Air.PubPc;
                Tc = Constants.Air.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.NH3))
            {
                M = Constants.Ammonia.PubM;
                Y = Constants.Ammonia.PubY;
                Pc = Constants.Ammonia.PubPc;
                Tc = Constants.Ammonia.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.A))
            {
                M = Constants.Argon.PubM;
                Y = Constants.Argon.PubY;
                Pc = Constants.Argon.PubPc;
                Tc = Constants.Argon.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C6H6))
            {
                M = Constants.Benzene.PubM;
                Y = Constants.Benzene.PubY;
                Pc = Constants.Benzene.PubPc;
                Tc = Constants.Benzene.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C4H9))
            {
                M = Constants.Isobutane.PubM;
                Y = Constants.Isobutane.PubY;
                Pc = Constants.Isobutane.PubPc;
                Tc = Constants.Isobutane.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C4H10))
            {
                M = Constants.n_Butane.PubM;
                Y = Constants.n_Butane.PubY;
                Pc = Constants.n_Butane.PubPc;
                Tc = Constants.n_Butane.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C4H8))
            {
                M = Constants.Isobutylene.PubM;
                Y = Constants.Isobutylene.PubY;
                Pc = Constants.Isobutylene.PubPc;
                Tc = Constants.Isobutylene.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.CO2))
            {
                M = Constants.Carbon_dioxide.PubM;
                Y = Constants.Carbon_dioxide.PubY;
                Pc = Constants.Carbon_dioxide.PubPc;
                Tc = Constants.Carbon_dioxide.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.CO))
            {
                M = Constants.Carbon_monoxide.PubM;
                Y = Constants.Carbon_monoxide.PubY;
                Pc = Constants.Carbon_monoxide.PubPc;
                Tc = Constants.Carbon_monoxide.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.Cl2))
            {
                M = Constants.Chlorine.PubM;
                Y = Constants.Chlorine.PubY;
                Pc = Constants.Chlorine.PubPc;
                Tc = Constants.Chlorine.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C2H6))
            {
                M = Constants.Ethane.PubM;
                Y = Constants.Ethane.PubY;
                Pc = Constants.Ethane.PubPc;
                Tc = Constants.Ethane.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C2H4))
            {
                M = Constants.Ethylene.PubM;
                Y = Constants.Ethylene.PubY;
                Pc = Constants.Ethylene.PubPc;
                Tc = Constants.Ethylene.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.F2))
            {
                M = Constants.Fluorine.PubM;
                Y = Constants.Fluorine.PubY;
                Pc = Constants.Fluorine.PubPc;
                Tc = Constants.Fluorine.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.CCl3F))
            {
                M = Constants.Freon_11.PubM;
                Y = Constants.Freon_11.PubY;
                Pc = Constants.Freon_11.PubPc;
                Tc = Constants.Freon_11.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.CCl2F2))
            {
                M = Constants.Freon_12.PubM;
                Y = Constants.Freon_12.PubY;
                Pc = Constants.Freon_12.PubPc;
                Tc = Constants.Freon_12.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.CClF))
            {
                M = Constants.Freon_13.PubM;
                Y = Constants.Freon_13.PubY;
                Pc = Constants.Freon_13.PubPc;
                Tc = Constants.Freon_13.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.CHClF2))
            {
                M = Constants.Freon_22.PubM;
                Y = Constants.Freon_22.PubY;
                Pc = Constants.Freon_22.PubPc;
                Tc = Constants.Freon_22.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.He))
            {
                M = Constants.Helium.PubM;
                Y = Constants.Helium.PubY;
                Pc = Constants.Helium.PubPc;
                Tc = Constants.Helium.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C7H16))
            {
                M = Constants.n_Heptane.PubM;
                Y = Constants.n_Heptane.PubY;
                Pc = Constants.n_Heptane.PubPc;
                Tc = Constants.n_Heptane.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.H2))
            {
                M = Constants.Hydrogen.PubM;
                Y = Constants.Hydrogen.PubY;
                Pc = Constants.Hydrogen.PubPc;
                Tc = Constants.Hydrogen.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.HCl))
            {
                M = Constants.Hydrogen_chloride.PubM;
                Y = Constants.Hydrogen_chloride.PubY;
                Pc = Constants.Hydrogen_chloride.PubPc;
                Tc = Constants.Hydrogen_chloride.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.HF))
            {
                M = Constants.Hydrogen_fluoride.PubM;
                Y = Constants.Hydrogen_fluoride.PubY;
                Pc = Constants.Hydrogen_fluoride.PubPc;
                Tc = Constants.Hydrogen_fluoride.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.CH4))
            {
                M = Constants.Methane.PubM;
                Y = Constants.Methane.PubY;
                Pc = Constants.Methane.PubPc;
                Tc = Constants.Methane.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.CH3Cl))
            {
                M = Constants.Methyl_chloride.PubM;
                Y = Constants.Methyl_chloride.PubY;
                Pc = Constants.Methyl_chloride.PubPc;
                Tc = Constants.Methyl_chloride.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.NG))
            {
                M = Constants.Natural_gas.PubM;
                Y = Constants.Natural_gas.PubY;
                Pc = Constants.Natural_gas.PubPc;
                Tc = Constants.Natural_gas.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.Ne))
            {
                M = Constants.Neon.PubM;
                Y = Constants.Neon.PubY;
                Pc = Constants.Neon.PubPc;
                Tc = Constants.Neon.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.NO))
            {
                M = Constants.Nitric_oxide.PubM;
                Y = Constants.Nitric_oxide.PubY;
                Pc = Constants.Nitric_oxide.PubPc;
                Tc = Constants.Nitric_oxide.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.N2))
            {
                M = Constants.Nitrogen.PubM;
                Y = Constants.Nitrogen.PubY;
                Pc = Constants.Nitrogen.PubPc;
                Tc = Constants.Nitrogen.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C8H18))
            {
                M = Constants.Octane.PubM;
                Y = Constants.Octane.PubY;
                Pc = Constants.Octane.PubPc;
                Tc = Constants.Octane.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.O2))
            {
                M = Constants.Oxygen.PubM;
                Y = Constants.Oxygen.PubY;
                Pc = Constants.Oxygen.PubPc;
                Tc = Constants.Oxygen.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C5H12))
            {
                M = Constants.Pentane.PubM;
                Y = Constants.Pentane.PubY;
                Pc = Constants.Pentane.PubPc;
                Tc = Constants.Pentane.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C3H8))
            {
                M = Constants.Propane.PubM;
                Y = Constants.Propane.PubY;
                Pc = Constants.Propane.PubPc;
                Tc = Constants.Propane.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.C3H6))
            {
                M = Constants.Propylene.PubM;
                Y = Constants.Propylene.PubY;
                Pc = Constants.Propylene.PubPc;
                Tc = Constants.Propylene.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.SS))
            {
                M = Constants.Saturated_steam.PubM;
                Y = Constants.Saturated_steam.PubY;
                Pc = Constants.Saturated_steam.PubPc;
                Tc = Constants.Saturated_steam.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.SO2))
            {
                M = Constants.Sulphur_dioxide.PubM;
                Y = Constants.Sulphur_dioxide.PubY;
                Pc = Constants.Sulphur_dioxide.PubPc;
                Tc = Constants.Sulphur_dioxide.PubTc;
            }
            else if (ddlCompressibleMedium.SelectedItem.ToString() == Functions.GetDescriptionFromAttribute(Data_Set.GasTypes.SHS))
            {
                M = Constants.Superheated_steam.PubM;
                Y = Constants.Superheated_steam.PubY;
                Pc = Constants.Superheated_steam.PubPc;
                Tc = Constants.Superheated_steam.PubTc;
            }
            else
            {
                MessageBox.Show("Please select a gas type");
                return;
            }

            // Specific heat ratio factor
            Fy = Equations.Eq34Fy(Y);

            //lblLCPRF.Content = "Liquid critical pressure ratio factor: " + Math.Round(Ff, 4, MidpointRounding.AwayFromZero);

            // Ratio of pressure differential to inlet absolute pressure (ΔP /P1)
            X = differentialPressure / inletPressure;

            // Choked or Non-choked flow
            if (X < Fy * Xt)
            {
                // calculate Y - Expansion factor - Eq32
                Y = Equations.Eq32Y(X, Fy, Xt);

                // Calculate C Eq6, 7 or 8

                C = Equations.Eq6C(Fl, N6, Y, X, inletPressure, SG);

                reynoldsnumber = Equations.Eq28Rev(flow, N4, Fd, viscosity, C, Fl, N2, linesize);
                temp = Math.Round(reynoldsnumber, 2, MidpointRounding.AwayFromZero);
                lblReynolds.Content = "Reynolds number: " + temp.ToString("#,##0");

                // Turbulant flow
                if (reynoldsnumber > 10000)
                {
                    // Line size and valve size are the same
                    if (linesize == valvesize)
                    {
                        lblflowCoefficient.Content = "Kv = " + Math.Round(C, 2, MidpointRounding.AwayFromZero);
                    }
                }
                else
                {
                    Fp = 1;
                    Ci = C;
                }

                lbldeltaPressure.Content = "Non-choked flow: " + Math.Round(X, 2, MidpointRounding.AwayFromZero) + "kPa";
            }
            else
            {
                // Expansion factor
                Y = 0.667;

                // Calculate C Eq12, 13 or 14

                lbldeltaPressure.Content = "Choked flow: " + Math.Round(X, 2, MidpointRounding.AwayFromZero) + "kPa";
            }

            //MessageBox.Show(Fy.ToString());

        }
        else
        {
            MessageBox.Show("Please select a fluid type");
            return;
        }


    }

}

