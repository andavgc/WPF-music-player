   M S B A M L   `   `   `  ����K  GWPF music player, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPF_music_playerWPF_music_player  5   	   !    WPF_music_player.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPF_music_player     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 
ResizeMode$ 	CanResize=�65   $	��450��6L   $	��450��6\   $	��450��6k   $	��450��6{   .��5      �  � RowDefinitions 5   
   �� 5   
   $��2* �6   �� 5   
   $��* �6   .+�5   
   �� $��0��6   ���#0E29546   �� 5   
   $��1��6   ���#84A7A16   �� 5   
   $��0��6   $��Center=�6"   $��Center=�6=    �� Orientation$ 
Horizontal=�6Z   .+�5      (�  (� Stretch$ Uniform=�6   .��5      � $��Right=�6   $��bottom=�63   .+�5      �� -   5        $��	songCover��5      $H��BC:\Users\USER\Documents\WPF music player\Assets\images\soundon.png��6-   5      5      5      (� 5   
   $ Uniform=�6   .��5      � $��Right=�6   $��bottom=�6/   .+�5      �� -   5        $��btnOpenAudioFile��5   z   ���#1F6E8C
�������$��1050, 650, 20, 20q�6A   $��60��6\   $	��220��6k   $��30(�6�   .��6�   Abrir arquivo6�   5      5      �� 5!   
   $��1��6   $��Stretch=�6"   $��Stretch=�6>   .+�5"      � .+�5#      �� $��Center=�6!   $��Center=�6<   $ 
Horizontal=�6Y   .+�5$      (� $��50��6"   $��20��6-   $ Uniform=�69   .��5%   "   �� -   5        $��	lblStatus��5%   (   $��Not playing...��69   $��Center=�6R   $��5q�6v   $��24(�6�   5&      (� 5'      $	��350��6"   $��20��6.   $ Uniform=�6:   $
��left=�6L   .��5(      � .+�5)   "   �� $I��CC:\Users\USER\Documents\WPF music player\Assets\images\duration.png��6(   �� 5*   "   -   5         ��Name$ 	TimeLapse��5*   (   $J��DC:\Users\USER\Documents\WPF music player\Assets\images\timeLapse.png��6;   $��0q�6�   5+      5,      (� 5-      $��50��6"   $��20��6-   $ Uniform=�69   .��5.   "   �� -   5        $��lblDuration��5.   (   $��00:00��6;   $��Center=�6K   $��5q�6o   $��24(�6z   5/      50      51      �� 53      $��Center=�6!   $ 
Horizontal=�6>   $��0, 0, 0, 10q�6W   .+�54      (� $��15��6"   $ Uniform=�6.   .��55      �� -   5        $��SongName��55   2   $��50(�6$   $�� ��6B   56      57      �� 59      $��Center=�6!   $��Center=�6<   $ 
Horizontal=�6Y   .+�5;      (� $��40��6"   $��40��6-   $ Uniform=�69   $��30, 0q�6K   .��5<      �� -   5        
������ 
������ .��5=      �� $I��CC:\Users\USER\Documents\WPF music player\Assets\images\previous.png��6$   5>      5?      (� 5A      $��80��6"   $��80��6-   $ Uniform=�69   $��30, 0q�6K   .��5B      � .+�5C      �� -   5        $��btnPlay��5C   %   
������ 
������ $y�Visible=�6y   .��5D   "   �� $E��?C:\Users\USER\Documents\WPF music player\Assets\images\play.png��6(   5E      �� 5F      -	   5        $��btnPause��5F   %   
������ 
������ $y�	Collapsed=�6z   .��5G   "   �� $F��@C:\Users\USER\Documents\WPF music player\Assets\images\pause.png��6(   5H      5I      5J      (� 5L      $��40��6"   $��40��6-   $ Uniform=�69   $��30, 0q�6K   .��5M      �� -
   5        
������ 
������ .��5N      �� $E��?C:\Users\USER\Documents\WPF music player\Assets\images\next.png��6$   5O      5P      5R      5U      �� 5W   
   $	��100��6   $	��100��6!   $��1��6.   $��Right=�6;   .+�5X      �� -   5         ��Name$ volumeSlider��5X   1    � Minimum$ 0Q�6G    � Maximum$ 1Q�6S   	 � Value$		 0.5Q�6_   
 �� Orientation$
 Vertical=�6k   $	��100��6�   $��20��6�   $��Center=�6�   5Y      5\      5]      