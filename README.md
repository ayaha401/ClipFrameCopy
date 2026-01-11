ClipFrameCopy
機能説明
Unity Timeline上で選択したクリップの開始・終了フレーム数をクリップボードにコピーするエディタ拡張ツールです。全てのトラックタイプに対応しており、複数のクリップを選択した際も一括でフレーム情報を取得できます。

導入方法
本ツールはUnity Editor拡張です。 配布されている .unitypackage をインポートするか、ソースコード (
ClipFrameCopy.cs
) をUnityプロジェクトの Editor フォルダ直下（例: Assets/Scripts/Editor/ClipFrameCopy/）に配置することで動作します。

使い方
Unity EditorでTimelineウィンドウを開きます。
フレーム数を確認したいクリップ（Animation Trackなど任意のトラック上のクリップ）を選択します（複数選択可）。
選択したクリップの上で 右クリック します。
コンテキストメニューから 「Copy Clip Frames」 を選択します。
クリップボードに以下の形式でフレーム情報がコピーされます。
ClipName : StartFrame~EndFrame
（例：Run : 10f~60f）
※複数選択時は改行区切りで出力されます。 ※Consoleウィンドウにもコピーされた内容がログ出力されます。
不具合
特記事項なし
