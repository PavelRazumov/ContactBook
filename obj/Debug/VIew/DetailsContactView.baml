   M S B A M L   `   `   `  ����F  BContactBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ContactBook.VIewContactBook.VIew  5      )    #ContactBook.VIew.DetailsContactView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:ContactBook.VIew     5      .��5	      � y�6   �� *SelectedContact+   SelectedContactConverter  �� 	Converter#  [   � ColumnDefinitions 5
   
   �� 5      5       � RowDefinitions 5   
   �� 5      $
��130* �6   5      �� 5      $	��95* �6   5      �� 5      $
��113* �6   5      �� 5      $	��32* �6   5      �� 5      $	��80* �6   .+�5!   
   � $��0��6   $��1��6   $��9.333,0,0,1q�6,    5"      �� 5#      6%   �� 5$      $	��200 �6#   61   .+�5'      �� $��0��6   
�������.+�5(      �� .+�5*      �� ��6   �� *SelectedContact.FirstName+ �� FallbackValue$	 N/A�� �� Mode$ TwoWay=�y�5+      �� *
IsEditMode+  isEditConverter#  [ .��5,      5.      �� 5/      $��24(�6   ��6+   �� *SelectedContact.FirstName+$	 N/A��y�50      �� *IsDisplayMode+#  [ 52      �� 55      ��6   �� *SelectedContact.LastName+$	 N/A��$ TwoWay=�y�56   !   �� *
IsEditMode+#  [ 57   #   �� 58      $��24(�6   ��6+   �� *SelectedContact.LastName+$	 N/A��y�59      �� *IsDisplayMode+#  [ 5:      5;      5<      �� 5=      $��1��6   
�������.+�5>      �� $	��150��6   $��40��6%   $��5q�61   ��6<   �� *SaveCommand+��5?      �� 5@      .+�5A      �� $��20(�6$   $��Medium"�62   .��6G   Save contact6U   5B      5D      5E      5F      �� 5H   
   $��1��6   $��1��6"   
�������$��9.333,2,0,0.667q�6J   .+�5I      �� .+�5J      �� ._�5K      �� $
��Bold"�6   $��Email��6.   6@   5L      5M      �� 5N      .+�5O      �� ��6   �� *SelectedContact.Email+$	 N/A��$ TwoWay=�y�5P      �� *
IsEditMode+#  [ .��5Q      5R      �� 5S      $��24(�6   ��6'   �� *SelectedContact.Email+$	 N/A��y�5T      �� *IsDisplayMode+#  [ 5V      5W      5X      �� 5Z   
   $��2��6   $��1��6"   
�������$��9.333,0.333,0,0q�6J   .+�5[      �� .+�5\      �� ._�5]      �� $
��Bold"�6   $��Phone number��6.   6G   5^      5_      �� 5`      .+�5a      �� ��6   �� *SelectedContact.PhoneNumber+$	 N/A��$ TwoWay=�y�5b      �� *
IsEditMode+#  [ .��5c      5d      �� 5e      $��24(�6   ��6'   �� *SelectedContact.PhoneNumber+$	 N/A��y�5f      �� *IsDisplayMode+#  [ 5h      5i      5j      �� 5l   
   $��3��6   $��1��6#   
�������$��2��6K   $��9.333,0,0,0q�6\   .+�5m      �� .+�5n      �� ._�5o      �� $
��Bold"�6   $��Birthday��6.   6C   5p      5q      �� 5r      .+�5s      �� ��6   �� *SelectedContact.BirthDate+$	 N/A��$ TwoWay=�y�5t      �� *
IsEditMode+#  [ .��5u      5v      �� 5w      $��24(�6   ��6'   �� *SelectedContact.BirthDate+$	 N/A��y�5x      �� *IsDisplayMode+#  [ 5z      5{      5|      5}      5~      