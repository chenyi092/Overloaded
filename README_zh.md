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
1. **Frontend**: 觀眾掃描 QR Code 後，在網頁上進行語音錄製。系統會即時解析音訊數據（包含分貝與頻率）。
2. **Backend (Firebase)**: 將分析後的數值資料即時反映至 Firebase Realtime Database。
3. **Unity**:
   - **Data Integration**: 從 Firebase 取得數據，並將其轉換為視覺化物件。
   - **Generative Art**: 根據取得的數值，生成獨特的「音聲精靈（Sound Sprite）」
   - **Live Operation**: 建置 Unity 的 UI 介面，並在正式演出中進行即時的視覺操作。
4. **Output**: 使用 NDI 將 Unity 的影像傳送並輸出至Dome投影系統。
## 實作亮點 | Technical Implementation & Key Highlights
1. **利用 Firebase 實作數據的即時取得與生成**<p>
實作了將從 Firebase 取得的觀眾音訊數據，直接反映於小精靈形態的演算法。
    - **音量**: 控制圓形點狀物向外擴散的範圍（半徑）。
    - **音高**: 控制生成的點狀物數量
   藉此，每一位觀眾的聲音都會化為獨特的視覺符號，投射至圓頂天幕。
2. **效能優化與記憶體管理**
針對大規模觀眾參與的演出，為維持系統穩定性，執行了以下處理：
   - 生命週期管理：控制生成的小精靈在 30 秒後自動銷毀，並限制同時存在的數量，以防止系統負載過大。
3. **全遠端異地共同開發 (Remote Collaboration)**
在留學期間的環境下，我與台灣團隊利用 Git 進行了協作開發。
      - **Version Control**: 透過 GitHub 進行程式碼管理。
      - **Workflow**: 即便在相隔兩地的情況下，仍完成了 Unity 專案的邏輯建構與 Firebase 連動，並實現了與現場投影系統的整合。
4. **特效模型與移動控制**
     - **動態移動控制**: 實作了移動演算法，使生成的精靈能在圓頂空間內自然地移動與追蹤，並符合演出的視覺意圖。
5. **建置現場演出專用的控制 UI**
   - **VJ演出**: 在 Unity 上建置了專屬的操作介面。在現場透過操作面板即時調整 Shader 與特效強度，實現了配合音樂的高動態現場演出。
## demo畫面
<p align="center">
  <img src="https://github.com/user-attachments/assets/fb08a75d-dca0-4966-9c24-22c2ff43f9a2" width="60%" />
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/2e71cee7-a226-4f3a-9391-404708f18673" width="50%" />
  <img src="https://github.com/user-attachments/assets/6edbfffb-ec89-494b-ae15-f2c44806a9d1" width="30%" />
</p>
