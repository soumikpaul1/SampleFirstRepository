   M S B A M L   `   `   `  ����  SMM.Configuration9    3SMM.Configuration.UserControls.SMMDatabaseSectionUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5        � 	Resources  5	       �� 
TargetType �� Property �� Value��%R   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 40 �6'   5      5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��48 �6   �� 5      $��* �6   �� 5      $��48 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��Right=�5      $��Center=�5      .+�5      �� -   5        $��BtnEditDatabase��5      $��0 0 5 0q�5      $��48��5      $��48��5      
������  /  +MahApps.Metro.Styles.MetroCircleButtonStyle#���   5      .��5      �� $��30��6   $��30��6#   $4��.pack://application:,,,/Images/EditDatabase.png��5      5      5       �� 5"   
   -   5        $��	DbSection��5#      $��SMM Database Section��5$      $��1��5%      .��5'      � -   5        $��GridSectionDetails��5'       5*      �� 5+      -   5         �Name$ DataProvider��5+   $   �� 5,      -   5        $ 
ServerName��5,   $   �� 5-      -   5        $
 Port��5-   $   �� 5.      -   5        $ DatabaseName��5.   $   �� 5/      -   5        $ ConnetionTimeOut��5/   $   �� 50      -	   5        $ CommandTimeOut��50   $   �� 51      -
   5        $ ServiceName��51   $   ��52      �� 53      " ��6$   .�54   "   ��  � ��$ 0 �6;    �� Triggers 55   "   �� 56   &    �� Binding 62   �� *IsOracleProvider+	 �� Mode$	 OneTime=�
 �� Value
 True6e   .a�57   *   ��  � ��$ * �6C   58   '   5:      5<      .+�5A      �� -   5        $��CmbDataProvider��5E        VirtualisedMetroComboBox#���  5A      *  $MahApps.Metro.Controls.TextBoxHelper   UseFloatingWatermark .    	Watermark$ Select Provider��5C       �� 
IsEditable .  �� SelectedIndex$ 0��5F      $��0��5G      $��2q�5H      .@�5I      �� .��5J      �� $��Oracle��6$   5K      �� 5L      .��5M      �� $��
SQL Server��6$   5N      �� 5O      .��5P      �� $��Sybase��6$   5Q      5R      �� 5S      $ Server Name��5T         ClearTextButton .  . $��1��5W      $��2q�6"   �� 5X      $
 Port��5Y       .  . $��2��5\      $��2q�6"   �� 5]      $ Database��5^       .  . $��3��5a      $��2q�6"   �� 5b      $ Connection Timeout��5c       .  . $��4��5f      $��2q�6"   �� 5g      $ Command Timeout��5h       .  . $��5��5k      $��2q�6"   �� 5l      $ Service Name��5m       .  . $��6��5p      $��2q�6"   5s      5u      �� 5v   
   $ 
Horizontal=�6   $��Right=�6.   $��2��5w      .+�5x      �� -   5        $��BtnReset��5x   %   $��Reset��6   $	��100��65   $��0 5 5 5q�5y      �� 5z      -   5        $��BtnSave��5z   $   $
��Save��6   $	��100��63   $��0 5 5 5q�5{      5~      5      5�      