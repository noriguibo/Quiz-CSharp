   M S B A M L   `   `   `  ���� C  ?Quiz ALG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Quiz_ALGQuiz_ALG      Quiz_ALG.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:Quiz_ALG       � Title$  Selecionar Quiz��$	��530��$	��800�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�����  �� ImageSource$&  /Resources/Images/background.png�� j� Stretch$ UniformToFill=� � 	Resources    FocusVisual �� Property �� Value	 �� StrokeDashArray
 J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 GreenButton �� 
TargetType �� 
TargetType ��Name ��Name �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName �� 
StartPoint �� EndPoint � Color � Offset  
SelectQuiz  	RedButton  PurpleButton  TitleButton  StandardBorderBrush  StandardBackgroundBrush  HoverBorderBrush  SelectedBackgroundBrush  SelectedForegroundBrush  DisabledForegroundBrush  
GlyphBrush  NormalBrush  NormalBorderBrush  HorizontalNormalBrush  HorizontalNormalBorderBrush  ListBoxBackgroundBrush  StandardBrush  PressedBrush  ScrollBarLineButton �� CornerRadius �� Path �� RelativeSource  ScrollBarPageButton  ScrollBarThumb   VerticalScrollBar � RowDefinitions ]� DecreaseRepeatButton ]� Thumb  ]� IncreaseRepeatButton ! HorizontalScrollBar! � ColumnDefinitions" �� Triggers " FavsScrollViewer# �� VerticalOffset$ � Value% �� ScrollableHeight& � Maximum' �� ViewportHeight( �� ViewportSize*) �� #ComputedVerticalScrollBarVisibility* �� Orientation+ �� HorizontalOffset, �� ScrollableWidth- �� ViewportWidth,. �� %ComputedHorizontalScrollBarVisibility��%   &	        &	 R     &	 g     &	 |     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     &	 a    &	 �    &	     7   7  7  &	 �
    7   7  7  &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	     &	 %    &	 8    &	 I    &	 \    &	 m    &	 �    &	 <    &	 �    7  7  7  7  7  &	 y    &	 Z    &	  M    7  7  7  7  7  7  7  &	!     7  7  7  7  7  7  7  '�� �    7 ! 7   &	"     �� .���  � �� �� .R��� $��2q�$		 1 2R�#��� ��$

 true��$��1���� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$

 True��._��� $ contentPresenter��#��z��#��z��# z $|�False��#��z��#��z��$
��True��#
 z
 #��z�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �� $	 0,0&�$	 1,1&�.��� $ #c2d2af��$ 1Q�� $ #d8eac2��$ 0Q�P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �� $	 0,0&�$	 1,1&�.��� $ #c2d2af��$ 1Q�� $ #d8eac2��$ 0Q��� " ��.���  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$

 True��._��� $ contentPresenter��#��z��#��z��# z $|�False��#��z��#��z��$
��True��#
 z
 #��z�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �� $	 0,0&�$	 1,1&�.��� $ #c0ddde��$ 1Q�� $ #a8c0c1��$ 0Q�P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �� $	 0,0&�$	 1,1&�.��� $ #c0ddde��$ 1Q�� $ #a8c0c1��$ 0Q��� " ��.���  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$

 True��._��� $ contentPresenter��#��z��#��z��# z $|�False��#��z��#��z��$
��True��#
 z
 #��z�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �� $	 0,0&�$	 1,1&�.��� $ #e2c3cd��$ 1Q�� $ #fedae6��$ 0Q�P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �� $	 0,0&�$	 1,1&�.��� $ #e2c3cd��$ 1Q�� $ #fedae6��$ 0Q��� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$

 True��._��� $ contentPresenter��#��z��#��z��# z $|�False��#��z��#��z��$
��True��#
 z
 #��z�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �� $	 0,0&�$	 1,1&�.��� $ #bdb1e2��$ 1Q�� $ #d6c9ff��$ 0Q�P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �� $	 0,0&�$	 1,1&�.��� $ #bdb1e2��$ 1Q�� $ #d6c9ff��$ 0Q��� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $ border��#��z��#��z��#��z��$

 true��._��� $ contentPresenter��$|�False��#��z��#��z��$
��True��#
 z
 #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border�� � ��
 ���� P�  � {�$
 true��. ��� $ border�� � ��
 ���� �� $ Black���� $ #bbf6e9���� $
 #DDD���� $ #92c1b6���� $ White���� $
 #888���� $ #bbf6e9���� $ #bbf6e9���� $ Black���� $ #a5d7cc���� $ Black���� $	 0,0&�$ 1,0.001&���� � $ White��$	 0.0Q�� $ White��$	 0.6Q�� $ #DDDDDD��$	 1.2Q��� $	 0,0&�$	 0,1&���� � $
 #FFF��$	 0.0Q�� $
 #CCC��$	 1.0Q��� $	 0,0&�$	 0,1&���� � $
 #BBB��$	 0.0Q�� $
 #EEE��$	 0.1Q�� $
 #EEE��$	 0.9Q�� $
 #FFF��$	 1.0Q��� " ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � |�$ false����  � �� �� " ��.R��� $��Border��$��1q�$ 2��8��  8�� $��1q�._�F� $��Center=�$��Center=�8�� ���� $ Content� �� *TemplatedParent+ P�  � ��$
 true��. ��� $ Border��8   � ��P�  � {�$ false��. ��� 8   � ���� " ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  � �� �� " ��.R��� 
���   ��� " n�.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  � �� �� " n�.R��� $ 4��#��z��#��z��$	��1.5q�$��8��$��8,0,-2,0q��� " ��.R��  �� $��0���� $��0.00001* ��� $��0��.+��� $��3��$ 2��
������ �� $��0��8��  $��18��$��ScrollBar.LineUpCommand��$��M 0 4 L 8 4 L 4 0 Z��]� $��
PART_Track��$��1��$
��true�� �� 8�� $��ScrollBar.PageUpCommand�� n� 8�� $��1,0,1,0q�8�� 8��   �� 8�� $��ScrollBar.PageDownCommand���� $��3��8�� $��18��$��ScrollBar.LineDownCommand��$��M 0 0 L 4 4 L 8 0 Z���� " ��.R�� ! �� $��18���� $��0.00001* ��� $��18��.+��� $��3��$ 2�����#F0F0F0�� $��0��8��  $��18��$��ScrollBar.LineLeftCommand��$��M 4 0 L 4 8 L 0 4 Z��]� $��
PART_Track��$��1��$��False�� �� 8�� $��ScrollBar.PageLeftCommand�� n� 8�� $��0,1,0,1q�8�� 8��   �� 8�� $ ��ScrollBar.PageRightCommand���� $��3��8�� $��18��$ ��ScrollBar.LineRightCommand��$��M 0 0 L 4 4 L 0 8 Z���� " ��.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true��" P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 18����  � ��8   P�  �@��Orientation$ Vertical=�. ���  � ��$ 18����  � ��$
 Auto����  � ��8  �� " ��.���  �@�OverridesDefaultStyle$
 True����  � �� �� " ��.R�� ! �� $
��Auto ���  �� �� $
��Auto �.+��� $��1���� $��PART_VerticalScrollBar��#$ z# #& z% #( z' #y�z) �� $��PART_HorizontalScrollBar��$* 
Horizontal=�$��1��$��1��#$ z+ #& z, #( z- #y�z. .��� -   / �Name$/ gridMain��! �� $��0* ��� $��0* ��� .+��� -   0 ��Name$0 lbMainBorder��
���   �$��2q�
������ $��3���� -   $0 
lbTitleBar��$��	0,0,0,478q�
���   �$��2q����#fde7d0$��3���� -   $0 lbTitle��$��9,8,506,487q�$��DemiBold"�$��Selecione um Quiz!��$��16(�$��Center=�
���   �
���   �$��2q�
�������$��3���� -   1 ��Name$1 
btMinimize��#��[ $��	696,6,0,0q�$��0q�$��3��$
��Left=�$	��Top=�$��40��$��43��.���� $$��/Resources/Images/minimize.png��$��UniformToFill=�$��36��$��36���� -   $1 btClose��#��[ $��	745,6,0,0q�$��0q�$��3��$
��Left=�$	��Top=�$��40��$��43��.���� $!��/Resources/Images/close.png��$��UniformToFill=�$��36��$��36��� $y�Visible=�$��3��$��20,25,233,16q�.+��� -   2 ��Name$2 lvQuizE�����#fde7d0
���   �$��2q�$��
2,56,10,15q�.@��� .+��� -   $1 
bt1stQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -	   $1 
bt2ndQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -
   $1 
bt3rdQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 
bt4thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 
bt5thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 
bt6thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 
bt7thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 
bt8thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 
bt9thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 bt10thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 bt11thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 bt12thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 bt13thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 bt14thQuizE��#���  $y�Visible=�$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� .+��� -   $1 bt15thQuizE��#���  $y�Visible=�$�� ��$��16(�$��DemiBold"�$��Center=�$��Center=�
���   ����#c0ddde
���   �$��2q�$	��509��$��60��$��60���� -   $1 btSelectQuiz��#���  $y�Visible=�$��DemiBold"�$
��Left=�$��SELECIONAR QUIZ��
���   �$��2q�
���   �$��20(����#fedae6$��2��$��580,409,0,31q�$	��192���� -   $1 
btEditQuiz��#��� 
 $
��Left=�$y�Hidden=�$��DemiBold"�$��EDITAR QUIZ��
���   �$��2q�
���   �$��20(����#d8eac2$��2��$��580,303,0,137q�$	��192���� -   $1 btResetQuiz��#���  $
��Left=�$y�Hidden=�$��DemiBold"�$��APAGAR QUIZ��
���   �$��2q�
���   �$��20(����#d6c9ff$��2��$��580,195,0,245q�$	��192��