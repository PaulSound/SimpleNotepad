   M S B A M L   `   `   `  ����H  DSimpleNotepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SimpleNotepadSimpleNotepad  5   	       SimpleNotepad.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SimpleNotepad     5   	     � Title$  PaulSound's Notepad��5   	   $	��600��6%   $	��650��62   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��.08* �6   �� 5      .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5        $��5,5,5,5q�5      $��80��6'   $��Create��62   $
��Bold"�6C   $��12(�6U   6c   �� 5      -   5        $��5,5,5,5q�5      $��80��6'   $
��Open��62   $
��Bold"�6A   $��12(�6S   6a   �� 5      -   5        $��5,5,5,5q�5      $��80��6'   $
��Save��62   $
��Bold"�6A   $��12(�6S   6a   �� 5      -   5        $��5,5,5,5q�5      $��80��6'   $��Save in Json��62   $
��Bold"�6I   $��12(�6[   6i   �� 5      -   5        $��5,5,5,5q�5      $��80��6'   $��Reset��62   $
��Bold"�6B   $��12(�6T   6b   5      �� 5   
   -   5         ��Name$ 
_notepadTB��5      $��1��6&   $��5,5,5,5q�63   " �� VerticalScrollBarVisibility$ Visible=�6D   $��15(�6k   $ �� HorizontalScrollBarVisibility$ Visible=�5       �� TextWrapping$ WrapWithOverflow=�6;    �� AcceptsReturn$
 True��6[   ��6p   �� *Text+5      5      