   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppleRepair.Views.WindowsAppleRepair.Views.Windows  5
   	   -    'AppleRepair.Views.Windows.MainAppWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	   	   9local'clr-namespace:AppleRepair.Views.Windows     5
   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   *   $AppleRepair.Views.Windows.BaseWindow    Loaded$  BaseWindow_Loaded��5   '      MaterialDesignBody#���   5        MaterialDesignPaper#���  5   	    � WindowStartupLocation$ CenterScreen=�5      $	��900��5   B   $
��1440��6O   $	��900��6\   $
��1340��6l    � Icon$  /Resources/Images/icon.ico��6|   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � Title 5   	   �� *WindowTitle+.��5      �  � RowDefinitions 5   
   �� 5      $��90 �6   �� 5      $
��255* �6    � ColumnDefinitions 5   
   �� 5      $	��240 �6   �� 5      $
��133* �6   .+�5   
   �� $��0,0,0,0q�6   $��5��6(   $��2��62   � 5   
   $��2��6   .+�5      �� -   5        $
��menu��5   1   $	��Top=�6   .+�5      �� $ ��/Resources/Images/logo.png��6   $��7q�6<   $	��150��6G   $	��150��6T    �� BitmapScalingMode$ HighQuality=�6`   �� 5      -   5         ��Name$ menuList��5      $��Stretch=�6W   $��Stretch=�6|    �� SelectedItem 6-   �� *SelectedItemMenu+��6�   �� *	MenuItems+��5      �� 5      	 �� DataType"	 ��6'   .R�5      �� 
 �� Orientation$
 
Horizontal=�6)   $��Stretch=�6B   .+�5   "   '  !MaterialDesignThemes.Wpf.PackIcon  
�������$��Center=�6c   $��Center=�6�   $��20��6�   $��20��6�   $��0,0,5,0q�6�      Kind 6:   �� *Icon+6�   �� 5    "   $��Center=�6C   $��20(�6^   ��6,   �� *Title+6^   5!      5"      ��5$      �� 5%       �� 
TargetType" ��6      MaterialDesignListBoxItem �� BasedOn# [ 6:   .�5&      ��  �� Property � �� �� Value �	#FF03A9F46;   �� 5'       � ��
 �����6;   �� 5(       � ��$ 3,0,5,5q�67    �� 	Resources 5)      ��%^   '��       �� 5*   "   " ��6(   .�5+   &   ��  �@��CornerRadius$ 5��6E   5,   #   5-      5.      50      51      �� 52      -   5        $��optionalMenu��52   4   $��Bottom=�6   .+�53      ��  6   �� *SelectedItemMenu+��6E   �� *OptionalMenuItems+��54      �� 55      "	 ��6'   .R�56      �� $
 
Horizontal=�6)   $��Stretch=�6B   .+�57   "     
�������$��Center=�6c   $��Center=�6�   $��0,0,5,0q�6�   $��20��6�   $��20��6�    6:   �� *Icon+6�   �� 58   "   $��20(�6C   ��6,   �� *Title+6C   59      5:      ��5<      �� 5=      " ��6    # [ 6:   .�5>      ��  � �� �	#FF03A9F46;   �� 5?       � ��
 �����6;   �� 5@       � ��$ 3,0,5,5q�67    5A      ��%^   '��       �� 5B   "   " ��6(   .�5C   &   ��  �@��CornerRadius$ 5��6E   5D   #   5E      5F      5H      5I      5J      � 5K   
   $��1��6   .+�5L      �� $
 
Horizontal=�6   $��Right=�62   .+�5M      �� $��16(�6:   $
��Wrap=�6H   $��Center=�6\   ��6   �� *UserFullName+6\   A� 5O      $��Right=�6   $��70��66   $��70��6A   $��5q�6M   ��5P      �� 5Q       j� Stretch$ UniformToFill=�6F   $ HighQuality=�6^    �� ImageSource 6%   �� *
UserIcon+6^   5S      5T      5U       � 5V   
   -   5        $��pageContainer��5V        � NavigationUIVisibility$ Hidden=�6%   $��0,0,0,0q�6E   $��1��6V   $��1��6f   5W      5X      