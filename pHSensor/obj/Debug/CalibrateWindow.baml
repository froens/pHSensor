   M S B A M L   `   `   `  ����R  NOxyPlot.Wpf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0>.clr-namespace:OxyPlot.Wpf;assembly=OxyPlot.WpfOxyPlot.Wpf  5       pHSensor   pHSensor.CalibrateWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >oxy.clr-namespace:OxyPlot.Wpf;assembly=OxyPlot.Wpf     5      -   5          �Name$  Window��5       � Title$ 	Calibrate��5      $	��640��5      $	��474��6    � 	Resources 5	       	  paras �� Source �� Current �� Source �� Path��%_   &	        �� 5
   
   -   5         5
   C   �� # Z $ Curve.Parameters�5      5      .��5      � -   5         �Name$ 
LayoutRoot��5      .+�5   
   �� $��Sigmoid: Boltzmann��6   $��	0,0,172,4q�6-   $��Right=�6@   $��26��6\   $��Bottom=�6h   �� 5   
   -   5        $��	Calibrate��5      $��Right=�6%   $��
0,366,10,0q�6A   $	��Top=�6U   $	��150��6m   $��43��6�   �� 5   
   $��Chi-square:��6   $
��Left=�6&   $��10,0,0,1q�6A   $��29��6S   $��Bottom=�6_   �� 5   
   -   5         ��Name$
 chi2��5      $��0��6   $
��Left=�6*   $��80,0,0,1q�6E   $��60��6W   $��29��6b   $��Bottom=�6n   �� 5   
   $��
Parameters��6   $��	0,10,10,0q�6'   $	��Top=�6:   $��Right=�6R   $	��150��6n   .��5      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 TblParameters��5      
   CanUserAddRows
 .  $	��150��6{   $	��Top=�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      AutoGenerateColumns .  $��Right=�6�   ��6E   �� # [     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width$ * 6)      
IsReadOnly .    Header$
 Name��6^   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Name+6^     5      $ * 6)   $ Value��6M    63   �� *Value+6M   5      5      �� 5   
   $��
Datapoints��6   $��
0,188,10,0q�6'   $	��Top=�6;   $��Right=�6S   $	��150��6o   .��5        -   5        $	 TblDataPoints��5      $��Right=�6�   $	��150��6�   $	��Top=�6�   $ * 6�    .  ��6c   �� *
DataPoints+# Z  5        5      $ * 6)   $ pH��63    6?   �� *Signal+  5       $ * 6)   $ Signal��63    6C   �� *pH+5"      5#      �� 5$   
   
���   �$��1q�6%   $��10,10,172,35q�69   ._�5%         OxyPlot.Wpf.Plot  -   5          Name$ 	PltVisual��5%      $��0,0,0,0q�6*      Axes 5&         OxyPlot.Wpf.LinearAxis  5'         OxyPlot.Wpf.Axis   Position$
 Left=�6%      Minimum$ 0Q�65      Maximum$ 10Q�6A      	MajorStep$ 1Q�6N      MajorGridlineStyle$	 Dot=�6\      MinorGridlineStyle$	 Dot=�6u      Title$ pH��6�     5(      $ Bottom=�6%   $ 0Q�67   $ 14Q�6C   $ 1Q�6P   $	 Dot=�6^   $	 Dot=�6w   $ Signal��6�      Series. 5*      	   OxyPlot.Wpf.ScatterSeries	  
   OxyPlot.Wpf.Series 
  Title$ Data points��6$   �   �OxyPlot.Wpf.ScatterSeries`1[[OxyPlot.Series.ScatterPoint, OxyPlot, Version=0.0.0.0, Culture=neutral, PublicKeyToken=638079a8f0bd61e9]]   
DataFieldX$ Signal��68      
DataFieldY$ pH��6L      
MarkerType$ Cross=�6\       
MarkerSize$  5Q�6o   !   MarkerStroke$! 	RoyalBlue��6~   ��6�   �� *
DataPoints+# Z    OxyPlot.Wpf.LineSeries  5+      -	   5        "  Name$
" line��5+   !   $ Fitted curve��6/   !   OxyPlot.Wpf.DataPointSeries#   
DataFieldX$# Signal��6D   $   
DataFieldY$$ pH��6X   %   
MarkerSize$% 5Q�6h   & 
  Color$& ForestGreen��6w   5,      5-      5.      5/      