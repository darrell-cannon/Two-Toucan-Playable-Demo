   M S B A M L   `   `   `  ����H  DTwoToucanGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TwoToucanGameTwoToucanGame  5   	       TwoToucanGame.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TwoToucanGame     5   	   -   5          � Title$  Two Toucans��5   	   $	��900��6   $
��1600��6*    � WindowState$ 	Maximized=�67   .��5      � ��5   
   �� 5       j� TileMode$
 Tile=�6    j� ViewportUnits$ Absolute=�6)    j� Viewport$ 0,0,400,400�6B    �� ImageSource$a [C:\Users\darre\source\repos\CreateImageCards\CreateImageCards\IconImagesAll\Dot Texture.jpg��6Y   6�   .+�5   
   � -   5        $��PlayersScoreButtons��5      61   � 5   
   -   5        $��CardsPlayedDisplayPanel��5      $��65,242,65,33q�64   5      �� 5   
   -   5        $��CardImageObject��5       �� CornerRadius$ 20,20,20,20��6)   $	��400��6E   $	��300��6R   ��5      �� 5      -   5        	CardImage��5   2   5      �� 5   
   -   5        $��StartButton��5   )   $	��Top=�6   $ 20,20,20,20��6=   
���   �$��10q�6l   $��92��6�   
�������$��670,56,670,0q�6�   ._�5       �� -   5           MyButtonStyle#��[  5       $��	ExtraBold"�6<   $��20(�6S   $��Segoe UI)�6a   $��0q�6w   
������ .��6�   Start5"      5#      �� 5&   
   -   5        $��ShowPlayedCardsButton��5&      $y�	Collapsed=�6/   $	��Top=�6F   $ 20,20,20,20��6^   
���   �$��10q�6�   $��92��6�   
�������$��670,56,670,0q�6�   ._�5'      �� -	   5        #��[  5'      $��	ExtraBold"�6<   $��20(�6S   $��Segoe UI)�6a   $��0q�6w   
������ .��6�   Reveal Cards5)      5*      � 5,   
   -
   5         �Name$ titleScreen��5,      .+�5-      �� $^��XC:\Users\darre\source\repos\CreateImageCards\CreateImageCards\IconImagesAll\sandwich.png��6   $��175,82,1227,629q�6v   6�   �� 5.      $Y��SC:\Users\darre\source\repos\CreateImageCards\CreateImageCards\IconImagesAll\bat.png��6   $��788,673,614,38q�6q   6�   �� 5/      $\��VC:\Users\darre\source\repos\CreateImageCards\CreateImageCards\IconImagesAll\potato.png��6   $��1269,586,133,125q�6t   6�   �� 50      $\��VC:\Users\darre\source\repos\CreateImageCards\CreateImageCards\IconImagesAll\toucan.png��6   $��1053,214,349,497q�6t   6�   �� 51      $^��XC:\Users\darre\source\repos\CreateImageCards\CreateImageCards\IconImagesAll\swimsuit.png��6   $��322,586,1080,125q�6v   6�   �� 52      -   5        $��title��52      $ 20,20,20,20��6#   
���   �$��10q�6R   
��� ���$��334,339,334,303q�6{   ._�53      �� $��Narkisim)�6   $��	ExtraBold"�62   $	��100(�6I   $��Center=�6X   $��Center=�6s   $
��Wrap=�6�   TWO TOUCANS6�   54      55      � 57   
   -   5        $ NumberOfPlayersPage��57      $y�	Collapsed=�6,   .+�58      �� $	��Top=�6   $ 20,20,20,20��6.   
���   �$��10q�6]   $	��420��6r   
��� ���$��525,242,525,0q�6�   ._�59      �� .+�5:      �� $ 20,20,20,20��6   
���   �$��10q�6L   $	��100��6a   $	��200��6n   
�������._�5;      �� -   5        #��[  5;   !   $��1 Player��6b   $��0q�6v   
������ 6�   5<      �� 5=      $ 20,20,20,20��6   
���   �$��10q�6L   $	��100��6a   $	��200��6n   
�������._�5>      �� -   5        #��[  5>   !   $��2 Player��6b   $��0q�6v   
������ 6�   5?      �� 5@      $ 20,20,20,20��6   
���   �$��10q�6L   $	��100��6a   $	��200��6n   
�������._�5A      �� -   5        #��[  5A   !   $��3 Player��6b   $��0q�6v   
������ 6�   5B      �� 5C      $ 20,20,20,20��6   
���   �$��10q�6L   $	��100��6a   $	��200��6n   
�������._�5D      �� -   5        #��[  5D   !   $��4 Player��6b   $��0q�6v   
������ 6�   5E      5F      5G      5I      � 5K   
   -   5        $ GetPlayerDetails��5K      $y�	Collapsed=�6)   $��0,700,0,700q�6@   .+�5M      �� -   5        $��playerDetailForm��5M      $	��Top=�6.   $ 20,20,20,20��6G   
���   �$��10q�6v   $	��423��6�   
��� ���$��525,-495,525,0q�6�   ._�5N      �� .+�5O      �� $��30(�6    Enter Player Details:6E   �� 5P      -   5        $��PlayerDetailsStackPanel��5P   !   5R      �� 5S      $ 20,20,20,20��6   
���   �$��10q�6L   $	��100��6a   $	��200��6n   
�������._�5T      �� -   5        #��[  5T   @   $��Click to Begin!��6g   $��0q�6�   
������ 6�   5U      5V      5W      5X      5Y      5Z      