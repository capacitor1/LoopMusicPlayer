# LoopMusicPlayer循环音乐播放器

## 介绍

可用于播放游戏内的特殊循环音乐，这种循环音乐分为2个文件：Intro和Loop。适用于游戏解包完毕之后的播放。

**此软件将Intro播放一遍之后开始循环播放Loop**，并且无需对原音频文件做任何修改。

> 音频播放部分使用了 [NAudio](https://github.com/naudio/NAudio)

## 支持的格式

`*.mp3;*.wav;*.ogg;*.m4a;*.aac;*.flac`

## 使用&功能

- 打开软件，选择Intro的文件路径。

- **此时会自动生成Loop的文件路径，如果预测的文件存在则会自动显示出来。**

- 如果没有自动生成Loop文件路径，就需要手动选择。

- 播放。

- 鼠标滚动或点击 `音量` 的箭头可调整音量，

- 点击 `停止` 结束播放（无法暂停，只能彻底结束），

- 无论软件处于什么状态，点击 `播放` 会打断当前操作并重新开始播放，

  - 如果正在播放，点击播放则会结束正在播放的内容，重新开始播放文件路径显示的新文件。

  - 如果正在播放但是文件路径的文件不正确，则会停止播放然后什么也不做。

- 状态指示中的 `长度` 和 `当前位置` 是**文件流中的字节位置而不是时长**。

![image](https://github.com/user-attachments/assets/43d71399-e5a9-4477-8d1d-eaf3b2c92ec2)
