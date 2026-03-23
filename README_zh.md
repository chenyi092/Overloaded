[繁體中文](./README_zh.md) | [日本語](./README.md)
# Overloaded
**Live Interactive Performance &amp; Generative Art at Taipei C-Lab Dome**
<p>
<img width="679" height="513" alt="image" src="https://github.com/user-attachments/assets/f5b99330-5251-4707-82cd-e00f249f6d38" />
</p>

## 作品概要 | Project Overview
本專案是整合了 Unity、Firebase 以及 Web 技術，在沉浸式圓頂（Dome）空間中進行的即時互動演出。<br>
在位於台北的 C-LAB Future Vision Lab Dome 進行演出，實現了將觀眾「聲音」視覺化的生成式表演。<p>
**互動流程：**
1. **参加**：觀眾在會場內掃描 QR Code，進入專屬網站。
2. **錄音、分析**: 在網頁上錄製音訊，並分析分貝（音量）與頻率（音高）。
3. **資料傳輸**: 分析後的數據會透過 Firebase Realtime Database 傳送到雲端。
4. **即時生成**: Unity 監視資料庫，並根據取得的數據生成獨特的「小精靈」。
5. **投影**: 產生的小精靈會經由 NDI，立即投射至 C-LAB Dome 的穹頂天幕。
## demo影片 | Demo Video
- [現場表演影像 1:07:22~1:15:20](https://www.youtube.com/watch?v=aa7Fg0g3TfM&t=4042s)<br>
備注：本影片為360度影片
- [互動網頁](https://overloaded.vercel.app/)
- [Unity的模擬操作紀錄](https://www.youtube.com/watch?v=64Kb6Im5Ydo)
## 作品理念 | Work Concept
過度製造是現今社會的問題之一，看似只是簡單的環保議題，然而非物質層面上也存在過度製造的問題。<br>
人們常有意識的為某事物賦予解釋，但或許真實相對單純；又或者無意識的被誘因吸引產生無意義的行為，進而讓自己陷入危機或徒增干擾。不論出於刻意或是無意，我們經常造成過度製造概念、行為、慾望等結果，因此希望透過與作品的互動，使觀眾能意識到此問題的存在。
## 團隊組成 | Team Members
本專案為 7 人團隊的共同創作。<p>
**負責部分：Unity**
- Firebase Realtime Database 的連動與數值讀取
- 實作小精靈的動態生成邏輯
- 模型出現特效以及在Dome空間內的移動控制
## 使用技術 | Tech Stack
本專案是一項整合了 Web、資料庫與遊戲引擎的即時互動演出。
1. **Frontend**: 観客が QR コードをスキャンし、Web 上で音声を録音。音声データをリアルタイムで解析（デシベルおよび周波数）
2. **Backend (Firebase)**: 解析された数値データを Firebase Realtime Database へ即時に反映。
3. **Unity**:
   - **Data Integration**: Firebase からデータを取得し、視覚的なオブジェクトへ変換。
   - **Generative Art**: 取得した数値に基づき、独自の「音声精霊（Sound Sprite）」を生成。
   - **Live Operation**: Unity の UI 界面を構築し、本番中のビジュアル操作をリアルタイムで実施。
4. **Output**: NDI を使用し、Unity の映像をドーム投影システムへ伝送・出力。
## 技術的実装と工夫 | Technical Implementation & Key Highlights
1. **Firebase を活用したデータの即時取得と生成**<p>
Firebase から取得した観客の音声データを、精霊の形態に直接反映させるアルゴリズムを実装しました。
    - **音量**: 小さな円状のドットが外側へ広がる範囲（半径）を制御
    - **音高**: 生成されるドットの個数を制御

   これにより、観客一人一人の声が独自の視覚的シンボルとしてドームの天井に投影されます
2. **パフォーマンス最適化とメモリ管理**
大規模な観客が参加するパフォーマンスにおいて、システムの安定性を保つため以下の処理を行いました。
   - ライフサイクル管理: 生成された精霊は 30 秒後に自動的に破棄されるよう制御し、同時存在数を制限することで、負荷の増大を防ぎました。
3. **全遠隔地からの共同開発 (Remote Collaboration)**
私は留学中という環境下で、台湾のチームと Git を活用して協調開発を行いました。
      - **Version Control**: GitHub によるソースコード管理。
      - **Workflow**: 遠隔地からでも Unity プロジェクトのロジック構築、Firebase 連携を完遂し、現場の投影システムとの統合を実現。
4. **特效モデルの挙動と移動制御**
     - **モーション制御**: 生成された精霊がドーム空間内を自然に、かつパフォーマンスの演出意図に沿って移動・追従するための移動アルゴリズムを実装しました。
5. **ライブパフォーマンス用コントロール UI の構築**
   - **VJ的演出**: Unity 上に独自の操作インターフェースを構築。現場で操作パネルから Shader やエフェクトの強度をリアルタイムで調整し、音楽に合わせたダイナミックなライブ演出を実現しました。
## デモ画面
<p align="center">
  <img src="https://github.com/user-attachments/assets/fb08a75d-dca0-4966-9c24-22c2ff43f9a2" width="60%" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/2e71cee7-a226-4f3a-9391-404708f18673" width="50%" />
  <img src="https://github.com/user-attachments/assets/6edbfffb-ec89-494b-ae15-f2c44806a9d1" width="30%" />
</p>
