   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel  5   	   C ?pHSensor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:pHSensorpHSensor 5   	      pHSensor.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   ScomponentModel8clr-namespace:System.ComponentModel;assembly=WindowsBase      5   	   (localclr-namespace:pHSensor      5   	   @d2http://schemas.microsoft.com/expression/blend/2008      5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   R NOxyPlot.Wpf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0$oxyplothttp://oxyplot.org/wpf  5   	     � Icon$  Resources/favicon.ico��5
   	    � Title$ 	pH-Sensor��5   	   $	��747��6   $	��802��6(    � 	Resources 5      %  pHSensor.InvertBooleanConverter   BoolConvert  CVSMeasurements �� Source �� Current �� Source �� SortDescriptions+   %System.ComponentModel.SortDescription   PropertyName   	Direction  CVSDarkMeasurements  CVSAArea  CVSBArea��%O  &	        &	      &	 �     &	     &	 �      5   
   6'   �� 5   
    6   �� *Measurements+# Z  5        5      $ 
WaveLength��61   $ 	Ascending=�6K   5      �� 5   
    6   �� *DarkMeasurements+# Z  5        5      $ 
WaveLength��61   $ 	Ascending=�6K   5      �� 5   
    6   �� *	AMeasures+# Z  5        5      $ 
WaveLength��61   $ 	Ascending=�6K   5      �� 5   
    6   �� *	BMeasures+# Z  5        5      $ 
WaveLength��61   $ 	Ascending=�6K   5!      5"      	 � DataContext	 5#      �� 5$   
   
 �� RelativeSource
 5%      �� 5&       �� Mode$
 Self=�6!   6/   5(       J� CommandBindings 5*      )  #System.Windows.Input.CommandBinding  5+   
   -   5           Command$ Close��5+      6)    J� InputBindings 5.      �� 5/   
    �� Command$ Close��6   
 �� Key$	 F11��6%   .��51      �� $��0,0,0,0q�6   .+�52   
   ]� .+�53      o� $	��Top=�6   .@�54      m� $��_File��6   .@�55      m� -   5        $��_Open Config��55       m� Icon 56      �� 57      $��Resources/Open.png��6$   6B   59      m� 5:      -   5        $��_Save Config��5:       5;      �� 5<      $��Resources/Save.png��6$   6B   5>      5?      m� 5@      $��_View��6   .@�5A      m� -   5        $��_Full screen��5A      6N   5B      5C      �� 5D      6   5E      � 5F   
   $��0,0,0,0q�6   .+�5G      �� -   5         ��Name$ BtnStart��5G      $��Start��6'   $��	10,10,0,0q�67   $��22��6]   $	��Top=�6i   $
��Left=�6�   $	��206��6�   �� 5H      -   5        $ 	BtnExport��5H      $��Export��6:   $��	10,37,0,0q�6K   $	��Top=�6^   $
��Left=�6v   $	��206��6�   {�6�   ��  �� Path$ 	IsRunning� �� 	Converter# [  �� 5I      -   5        $ BtnCalibrate��5I      $��	Calibrate��6+   $��	10,64,0,0q�6?   $	��Top=�6R   $
��Left=�6�   $	��206��6�   {�6�   �� $ 	IsRunning�# [  �� 5J      -   5        $ BtnLampe��5J      $��Switch lamp��6'   $��	10,91,0,0q�6=   $	��Top=�6P   $
��Left=�6~   $	��206��6�   {�6�   �� $ 	IsRunning�# [  �� 5K      -	   5        $ BtnDarkMeasurement��5K      $��Dark measurement��61   $��
10,118,0,0q�6L   $	��Top=�6`   $
��Left=�6�   $	��206��6�   {�6�   �� *	IsRunning+# [  �� 5L      $��Settings��6   $��
10,145,0,0q�6)   $	��Top=�6=   $	��195��6U   $
��Left=�6b   $	��206��6}   .��5M      � $��Right=�6   $��0,0,0,10q�63    � RowDefinitions 5N      �� 5O      $
��Auto �6(   �� 5P      $
��Auto �6(   �� 5Q      $
��Auto �6(   �� 5R      $
��Auto �6(   �� 5S      $
��Auto �6(   �� 5T      $
��Auto �6(    � ColumnDefinitions 5V      �� 5W      $
��Auto �6+   �� 5X      $
��Auto �6+   .+�5[      �� $��Average��6   $��0��6.   $��1��6>   $��0,0,5,5q�6K   $��Right=�6\   �� 5\      -
   5         ��Name$ TxtAv��5\      $��1��6-   $��1��6=    �� TextWrapping$
 Wrap=�6J   $��7��6^   $��0,0,0,5q�6g   {�6x   �� $ 	IsRunning�# [  �� 5^      $��0��6   $��2��6,   $��Integration time��69   $��Right=�6T   $��0,0,5,5q�6p   ]� 5_      $��2��6    $��1��6-   $��0,0,0,5q�6=   .+�5`      �� -   5        $ TxtTint��5`   "   $
 Wrap=�63   $��40��6G   $��36��6Q   {�6\   �� $ 	IsRunning�# [  �� 5a      $��ms��6    5b      �� 5d      $��0��6   $��3��6,   $��A��69   $��0,0,5,5q�6E   $��Right=�6V   ]� 5e      $��3��6    $��1��6-   $��0,0,0,5q�6=   .+�5f      �� -   5        $ 	TxtAStart��5f   "   $��0,0,5,0q�65   $
 Wrap=�6F   $	��600��6Z   $��36��6e   {�6p   �� $ 	IsRunning�# [  �� 5g      -   5        $ TxtAEnd��5g   "   $
 Wrap=�63   $	��625��6G   $��36��6R   {�6]   �� $ 	IsRunning�# [  5h      �� 5j      $��B��6   $��0��6(   $��4��68   $��0,0,5,5q�6E   $��Right=�6V   ]� 5k      $��1��6    $��4��60   $��0,0,0,5q�6=   .+�5l      �� -   5        $ 	TxtBStart��5l   "   $��0,0,5,0q�65   $
 Wrap=�6F   $	��750��6Z   $��36��6e   {�6p   �� $ 	IsRunning�# [  �� 5m      -   5        $ TxtBEnd��5m   "   $
 Wrap=�63   $	��775��6G   $��36��6R   {�6]   �� $ 	IsRunning�# [  5n      �� 5p      $��0��6   $��5��6,   $��Interval��69   $��Right=�6L   $��0,0,5,5q�6h   ]� 5q      $��5��6    $��1��6-   $��0,0,0,5q�6=   .+�5r      �� -   5        $ TxtInterval��5r   "   $
 Wrap=�67   $��40��6K   $��36��6U   {�6`   �� $ 	IsRunning�# [  �� 5s      $��s��6    5t      5u      5v      �� 5w      $��Output��6   $��221,10,10,0q�6'   $	��330��6<   $	��Top=�6I   .��5x      �� -   5         ��Name$ 	LblOutput��5x      5y      �� 5z      $��Graph��6   $��10,345,10,-345q�6&   .��5{        OxyPlot.Wpf.Plot  -   5          Name$
 Plot��5{         Axes 5|        OxyPlot.Wpf.LinearAxis  5}      -   5          Name$ AxisWaveLength��5}   -     OxyPlot.Wpf.Axis   Title$ Wavelength (nm)��6E      Position$ Bottom=�6]      Minimum$	 530Q�6o       Maximum$
  1000Q�6}   !   Series.! 5�        OxyPlot.Wpf.AreaSeries  -   5        "  Name$" AreaSeriesA��5�   )     OxyPlot.Wpf.Series#   Title$# A��6>   $   DataFieldX2$$ 
WaveLength��6H   %   DataFieldY2$
% Zero��6a   !	  OxyPlot.Wpf.DataPointSeries& 	  
DataFieldX$& 
WaveLength��6t   ' 	  
DataFieldY$' 	Intensity��6�   (   Fill$( 	PaleGreen��6�   )   Color$) Transparent��6�   ��6�   �� # [   5�      -   5        $" AreaSeriesB��5�   )   $# B��6>   $$ 
WaveLength��6H   $
% Zero��6a   $& 
WaveLength��6t   $' 	Intensity��6�   $( PaleVioletRed��6�   $) Transparent��6�   ��6�   �� # [ 
  OxyPlot.Wpf.LineSeries
  5�      -   5        * 
 Name$* PltLineSeries��5�   )   $# Measurement��6@   $& 
WaveLength��6T   $' 	Intensity��6l   ��6�   �� # [ 
  5�      -   5        $* PltDarkLineSeries��5�   )   $# Dark Measurement��6D   $& 
WaveLength��6]   $' 	Intensity��6u   ��6�   �� # [ 5�      5�      � 5�      -   5        + �Name$+ 
LoadingBar��5�      $y�Hidden=�6'   $��0,0,0,0q�6;   ��5�      �� 5�      , �� Color$, 	LightGray��6&   - �� Opacity$	- 0.5Q�68   .+�5�      �� 
���   �. �� Padding$. 3q�6-   $��1q�69   $��Center=�6N   $��Center=�6k   
�������._�5�      �� .+�5�      �� -   5        $ 
LblLoading��5�   2   $��Loading��6    $��Center=�6F   � 5�      $��26��6&   / � IsIndeterminate/ . $	��300��6I   5�      5�      5�      5�      5�      5�      