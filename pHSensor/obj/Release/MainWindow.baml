   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R8clr-namespace:System.ComponentModel;assembly=WindowsBaseSystem.ComponentModel  C ?pHSensor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:pHSensorpHSensor    pHSensor.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      ScomponentModel8clr-namespace:System.ComponentModel;assembly=WindowsBase      (localclr-namespace:pHSensor      @d2http://schemas.microsoft.com/expression/blend/2008      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      R NOxyPlot.Wpf, Version=0.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0$oxyplothttp://oxyplot.org/wpf    � Icon$  favicon.ico�� � Title$ 	pH-Sensor��$	��747��$	��802�� � 	Resources %  pHSensor.InvertBooleanConverter   BoolConvert  CVSMeasurements �� Source �� Current �� Source �� SortDescriptions+   %System.ComponentModel.SortDescription   PropertyName   	Direction  CVSDarkMeasurements  CVSAArea  CVSBArea��%u  &	        &	      &	 U     &	 �     &	 �       ��  �� *Measurements+# Z    $ 
WaveLength��$ 	Ascending=���  �� *DarkMeasurements+# Z    $ 
WaveLength��$ 	Ascending=���  �� *	AMeasures+# Z    $ 
WaveLength��$ 	Ascending=���  �� *	BMeasures+# Z    $ 
WaveLength��$ 	Ascending=�	 � DataContext	 �� 
 �� RelativeSource
 ��  �� Mode$
 Self=� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ Close�� J� InputBindings ��  �� Command$ Close��
 �� Key$	 F11��.���� $��0,0,0,0q�.+�]� .+�o� $	��Top=�.@�m� $��_File��.@�m� -   $��_Open Config�� m� Icon �� $��Resources/Open.png��m� -   $��_Save Config�� �� $��Resources/Save.png��m� $��_View��.@�m� -   $��_Full screen���� � $��0,0,0,0q�.+��� -    ��Name$ BtnStart��$��Start��$��	10,10,0,0q�$��22��$	��Top=�$
��Left=�$	��206���� -   $ 	BtnExport��$��Export��$��	10,37,0,0q�$	��Top=�$
��Left=�$	��206��{���  �� Path$ 	IsRunning� �� 	Converter# [  �� -   $ BtnCalibrate��$��	Calibrate��$��	10,64,0,0q�$	��Top=�$
��Left=�$	��206��{��� $ 	IsRunning�# [  �� -   $ BtnLampe��$��Switch lamp��$��	10,91,0,0q�$	��Top=�$
��Left=�$	��206��{��� $ 	IsRunning�# [  �� -	   $ BtnDarkMeasurement��$��Dark measurement��$��
10,118,0,0q�$	��Top=�$
��Left=�$	��206��{��� *	IsRunning+# [  �� $��Settings��$��
10,145,0,0q�$	��Top=�$	��195��$
��Left=�$	��206��.��� $��Right=�$��0,0,0,10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto �.+��� $��Average��$��0��$��1��$��0,0,5,5q�$��Right=��� -
    ��Name$ TxtAv��$��1��$��1�� �� TextWrapping$
 Wrap=�$��7��$��0,0,0,5q�{��� $ 	IsRunning�# [  �� $��0��$��2��$��Integration time��$��Right=�$��0,0,5,5q�]� $��2��$��1��$��0,0,0,5q�.+��� -   $ TxtTint��$
 Wrap=�$��40��$��36��{��� $ 	IsRunning�# [  �� $��ms���� $��0��$��3��$��A��$��0,0,5,5q�$��Right=�]� $��3��$��1��$��0,0,0,5q�.+��� -   $ 	TxtAStart��$��0,0,5,0q�$
 Wrap=�$	��600��$��36��{��� $ 	IsRunning�# [  �� -   $ TxtAEnd��$
 Wrap=�$	��625��$��36��{��� $ 	IsRunning�# [  �� $��B��$��0��$��4��$��0,0,5,5q�$��Right=�]� $��1��$��4��$��0,0,0,5q�.+��� -   $ 	TxtBStart��$��0,0,5,0q�$
 Wrap=�$	��750��$��36��{��� $ 	IsRunning�# [  �� -   $ TxtBEnd��$
 Wrap=�$	��775��$��36��{��� $ 	IsRunning�# [  �� $��0��$��5��$��Interval��$��Right=�$��0,0,5,5q�]� $��5��$��1��$��0,0,0,5q�.+��� -   $ TxtInterval��$
 Wrap=�$��40��$��36��{��� $ 	IsRunning�# [  �� $��s���� $��Output��$��221,10,10,0q�$	��330��$	��Top=�.���� -    ��Name$ 	LblOutput���� $��Graph��$��10,345,10,-345q�.��  OxyPlot.Wpf.Plot  -     Name$
 Plot��   Axes   OxyPlot.Wpf.LinearAxis  -     Name$ AxisWaveLength��  OxyPlot.Wpf.Axis   Title$ Wavelength (nm)��   Position$ Bottom=�   Minimum$	 530Q�    Maximum$
  1000Q�!   Series.!   OxyPlot.Wpf.AreaSeries  -   "  Name$" AreaSeriesA��  OxyPlot.Wpf.Series#   Title$# A��$   DataFieldX2$$ 
WaveLength��%   DataFieldY2$
% Zero��!	  OxyPlot.Wpf.DataPointSeries& 	  
DataFieldX$& 
WaveLength��' 	  
DataFieldY$' 	Intensity��(   Fill$( 	PaleGreen��)   Color$) Transparent������ # [   -   $" AreaSeriesB��$# B��$$ 
WaveLength��$
% Zero��$& 
WaveLength��$' 	Intensity��$( PaleVioletRed��$) Transparent������ # [ 
  OxyPlot.Wpf.LineSeries
  -   * 
 Name$* PltLineSeries��$# Measurement��$& 
WaveLength��$' 	Intensity������ # [ 
  -   $* PltDarkLineSeries��$# Dark Measurement��$& 
WaveLength��$' 	Intensity������ # [ � -   + �Name$+ 
LoadingBar��$y�Hidden=�$��0,0,0,0q����� , �� Color$, 	LightGray��- �� Opacity$	- 0.5Q�.+��� 
���   �. �� Padding$. 3q�$��1q�$��Center=�$��Center=�
�������._��� .+��� -   $ 
LblLoading��$��Loading��$��Center=�� $��26��/ � IsIndeterminate/ . $	��300��