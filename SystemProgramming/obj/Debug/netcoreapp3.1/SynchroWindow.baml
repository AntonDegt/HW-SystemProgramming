   M S B A M L   `   `   `  ����L  HSystemProgramming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SystemProgrammingSystemProgramming  5   	   %    SystemProgramming.SynchroWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SystemProgramming     5   	     � Title$  SynchroWindow��5   	   $	��500��6   $	��600��6,   .��5
      �  � ShowGridLines$
 True��6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��5q�6%   .+�5      �� $
��Bold"�6   $��24(�6&   .��64   Synhronization object6K   �� 5      $��18(�6   .��6"   	1. Lock6+   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��ButtonStart1��5      $��18(�5      $
��10 5q�6'   .��5   D   Start6K   5      �� 5      $��18(�6   $��0 10 0 0q�6"   .��64   
2. Monitor6@   �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $��ButtonStart2��5      $��18(�5      $
��10 5q�6'   .��5   D   Start6K   5      �� 5       $��18(�6   $��0 10 0 0q�6"   .��64   
3. Mutex6>   �� 5!      $ 
Horizontal=�6   .+�5"      �� -   5        $��ButtonStart3��5#      $��18(�5"      $
��10 5q�6'   .��5#   D   Start6K   5$      �� 5&      $��18(�6   $��0 10 0 0q�6"   .��64   4. EventWaitHandle6H   �� 5'      $ 
Horizontal=�6   .+�5(      �� -   5        $��ButtonStart4��5)      $��18(�5(      $
��10 5q�6'   .��5)   D   Start6K   5*      �� 5,      $��18(�6   $��0 10 0 0q�6"   .��64   5. Semaphore6B   �� 5-      $ 
Horizontal=�6   .+�5.      �� -   5        $��ButtonStart5��5/      $��18(�5.      $
��10 5q�6'   .��5/   D   Start6K   50      51      �� 53   
   -   5        $��ConcoleBlock��53   $   $��1��6   $��16(�68    �� Padding$ 5q�6F   54      55      