   M S B A M L   `   `   `  ����  	XeroxTest#    XeroxTest.View.MainWindowView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��725��6)   .��5      � .+�5   
   �� .+�5      �� $��10,8,0,3q�6   $��20(�6*   Solar System's Tree:6N   R� 5      -   5         R�Name$ SolarSystemTreeView��5   =   $��10,3,0,3q�6   $��0q�6)   $
��Left=�6�   $	��250��6�   $��Stretch=�6�   ��6�   ��  �� Path$ SpaceObjects� �� Mode$ TwoWay=���5	      �� 5
       �� ItemsSource 6/   �� $ ChildrensCollection�$ TwoWay=�.R�5      �� .+�5      �� ��6(   �� $
 Name�$ TwoWay=�6R   5      5       � 	Resources 5       �� 
TargetType �� Property �� Value��%�   'Q�       �� 5      " Q�6   .�5      ��  �@Q�
IsExpanded 67   �� $ 
IsExpanded�$ TwoWay=�6h   5      5      5      5      �� 5   
   -   5        	 ��Name$ 	 AdditionInfoContentControl��5      $y�	Collapsed=�6=   $	��450��6�   $
��Left=�6�   $��	250,0,0,0q�6�   ��6T   �� 
 �� ElementName$
 SolarSystemTreeView��$ SelectedItem���5      �� 5      .R�5      � $��5q�6   .+�5      �� .+�5      �� $��0,3,0,3q�6(   $��20(�69   ��6G   �� $
 Name�$ TwoWay=��� 5      $��0,7,0,7q�6$   $	��150��6z   $
��Left=�6�   ��65   �� $ 	ImageData� � ToolTip 6W   �� $ 	ImageHint�6�   �� 5      $��0,3,0,3q�6(   ��69   �� $ WikiPage�$ TwoWay=��� 5       $��0,3,0,3q�6(   Mean radius: �� 6G   �6K   �� $ MeanRadiusInKm�
 km — �� 6y   �6}   �� $ MeanRadiusByEarth� Earth's radius6�   �� 5!      $��0,3,0,3q�6(   
Volume: �� 6B   �6F   �� $ Volume10Pow9Km3�*10�� 6q   $�9��6u   $��9(�6~    �� BaselineAlignment$	 Top=�6�    km�� 6�   $�3��6�   $��9(�6�   $	 Top=�6�    — �� 6�   �6�   �� $ VolumeByEarth� Earth's volume6  �� 5"      $��0,3,0,3q�6(   Mass: �� 6@   �6D   �� $ Mass10Pow21Kg�*10�� 6m   $�21��6q   $��9(�6{   $	 Top=�6�   
 kg — �� 6�   �6�   �� $ MassByEarth� Earth's mass6�   �� 5#      $��0,3,0,3q�6(   	Destiny: �� 6C   �6G   �� $ DestinygByCm3� cm�� 6p   $�3��6t   $��9(�6}   $	 Top=�6�   6�   �� 5$      $��0,3,0,3q�6(   Surface gravity: �� 6K   �6O   �� $ SurfaceGravitymByS2�m/s�� 6~   $�2��6�   $��9(�6�   $	 Top=�6�    — �� 6�   �6�   �� $ SurfaceGravityByEarth� Earth's surface gravity6  �� 5%      $��0,3,0,3q�6(   Type of object: �� 6J   �6N   �� $ TypeOfObject�$ TwoWay=�6�   5&      5'      5(      5*      5+      5,      