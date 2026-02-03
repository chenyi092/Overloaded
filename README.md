# Overloaded
**Live Interactive Performance &amp; Generative Art at Taipei C-Lab Dome**
<p>
<img width="679" height="513" alt="image" src="https://github.com/user-attachments/assets/f5b99330-5251-4707-82cd-e00f249f6d38" />
</p>

## プロジェクト概要 | Project Overview
本プロジェクトは、Unity、Firebase、および Web 技術を統合した、没入型ドーム（Dome）空間でのリアルタイム・インタラクティブ・パフォーマンスです。<br>
台湾にある C-LAB Future Vision Lab Dome でパフォーマンスをし、観客の「声」を視覚化する生成的な演出を実現しました。<p>
**インタラクションのフロー：**
1. **参加**：観客は会場内で QR コードをスキャンし、専用の Web サイトにアクセスします。
2. **録音・解析**: Web 上で音声を録音し、デシベル（音量）と周波数（音高）を解析します。
3. **データ送信**: 解析されたデータは Firebase Realtime Database を通じてクラウドへ送信されます。
4. **リアルタイム生成**: Unity がデータベースを監視し、取得したデータに基づいて独自の「Sprite」を生成します。
5. **投影**: 生成されたSpriteは NDI を介して、C-LAB Dome の天井に即座に投影されます。
## デモ動画 | Demo Video
- [現場でのパフォーマンス映像 1:07:22~1:15:20](https://www.youtube.com/watch?v=aa7Fg0g3TfM&t=4042s)<br>
注：本映像は YouTube の 360 度動画に対応しています
- [インタラクティブ Web サイト](https://overloaded.vercel.app/)
- [Unity 上での操作シミュレーション](https://www.youtube.com/watch?v=64Kb6Im5Ydo)
## 作品コンセプト | Work Concept
過剰生産は現代社会が抱える問題の一つです。それは単なる環境問題にとどまらず、非物質的な側面においても存在しています。 人間はしばしば、ある物事に対して意識的に解釈を付与しようとしますが、実際にはもっと単純なものかもしれません。あるいは、無意識に誘惑に引かれ、無意味な行動を繰り返すことで、自らを危機に陥れたり、余計な干渉を増やしたりすることもあります。 意図的か無意識かにかかわらず、私たちは概念、行為、欲望などを過剰に作り出してしまう傾向があります。本作品とのインタラクションを通じて、観客がこの問題の存在に気づくきっかけとなることを願っています。
## チーム構成 | Team Members
本プロジェクトは 7 人のチームによる共同制作です。<p>
**担当部分：Unity**
- Firebase Realtime Database の連携・数値取得の全般
- Sprite の動的生成ロジックの実装
- モデルの出現エフェクトおよびドーム空間内での移動制御
## 技術スタック | Tech Stack
本プロジェクトは、Web、データベース、ゲームエンジンを統合したリアルタイム・インタラクティブ・パフォーマンスです。
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


