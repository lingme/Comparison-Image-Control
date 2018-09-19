# WPF 交替图片显示控件
---
WPF实现的图片交替显示控件，可以叠加两层。

##### 命名空间引入：
```C {.line-numbers}
xmlns:control="clr-namespace:DoubleStaff;assembly=DoubleStaff"
```

##### 使用：

```C {.line-numbers}
<control:DoubleStaffImage 
        BottomImage="Image/bottom.jpg" 
        TopImage="Image/top.jpg">
</control:DoubleStaffImage>
```

##### 属性：

| 属 性        | 类 型   |  说 明  |
| --------   | -----  | ----  |
|BottomImage|ImageSource|底图|
|TopImage|ImageSource|叠加图|

##### 效果
![fdfd](https://github.com/lingme/Picture_Bucket/raw/master/Alternate_Image_Img/AlternateGif.gif)