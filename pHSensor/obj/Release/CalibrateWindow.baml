   M S B A M L   `   `   `  ���� R  NOxyPlot.Wpf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0>.clr-namespace:OxyPlot.Wpf;assembly=OxyPlot.WpfOxyPlot.Wpf   pHSensor   pHSensor.CalibrateWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     >oxy.clr-namespace:OxyPlot.Wpf;assembly=OxyPlot.Wpf     -     �Name$  Window�� � Title$ 	Calibrate��$	��640��$	��474�� � 	Resources  	  paras �� Source �� Current �� Source �� Path��%;   &	        �� -    �� # Z $ Curve.Parameters�.��� -    �Name$ 
LayoutRoot��.+��� $��Sigmoid: Boltzmann��$��	0,0,172,4q�$��Right=�$��26��$��Bottom=��� -   $��	Calibrate��$��Right=�$��
0,366,10,0q�$	��Top=�$	��150��$��43���� $��Chi-square:��$
��Left=�$��10,0,0,1q�$��29��$��Bottom=��� -    ��Name$
 chi2��$��0��$
��Left=�$��80,0,0,1q�$��60��$��29��$��Bottom=��� $��
Parameters��$��	0,10,10,0q�$	��Top=�$��Right=�$	��150��.��&   System.Windows.Controls.DataGrid  -   	  Name$	 TblParameters��
   CanUserAddRows
 .  $	��150��$	��Top=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    AutoGenerateColumns .  $��Right=����� # [     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width$ *    
IsReadOnly .    Header$
 Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $ * $ Value�� �� *Value+�� $��
Datapoints��$��
0,188,10,0q�$	��Top=�$��Right=�$	��150��.��  -   $	 TblDataPoints��$��Right=�$	��150��$	��Top=�$ *  .  ���� *
DataPoints+# Z    $ * $ pH�� �� *Signal+  $ * $ Signal�� �� *pH+�� 
���   �$��1q�$��10,10,172,35q�._�   OxyPlot.Wpf.Plot  -     Name$ 	PltVisual��$��0,0,0,0q�   Axes    OxyPlot.Wpf.LinearAxis     OxyPlot.Wpf.Axis   Position$
 Left=�   Minimum$ 0Q�   Maximum$ 10Q�   	MajorStep$ 1Q�   MajorGridlineStyle$	 Dot=�   MinorGridlineStyle$	 Dot=�   Title$ pH��  $ Bottom=�$ 0Q�$ 14Q�$ 1Q�$	 Dot=�$	 Dot=�$ Signal��   Series. 	   OxyPlot.Wpf.ScatterSeries	  
   OxyPlot.Wpf.Series 
  Title$ Data points���   �OxyPlot.Wpf.ScatterSeries`1[[OxyPlot.Series.ScatterPoint, OxyPlot, Version=0.0.0.0, Culture=neutral, PublicKeyToken=638079a8f0bd61e9]]   
DataFieldX$ Signal��   
DataFieldY$ pH��   
MarkerType$ Cross=�    
MarkerSize$  5Q�!   MarkerStroke$! 	RoyalBlue������ *
DataPoints+# Z    OxyPlot.Wpf.LineSeries  -	   "  Name$
" line��$ Fitted curve��!   OxyPlot.Wpf.DataPointSeries#   
DataFieldX$# Signal��$   
DataFieldY$$ pH��%   
MarkerSize$% 5Q�& 
  Color$& ForestGreen��