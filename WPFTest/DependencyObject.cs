using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFTest
{
	/// <summary>
	/// 依存関係プロパティを定義するクラスの最低限の実装例
	/// </summary>
	public class DependencyPoint : DependencyObject
	{
		//実際のデータの読み書きはSetValue/GetValueメソッドにて行われる。

		/// <summary>
		/// CLRプロパティの定義
		/// ※データバインディングなどを行うとCLRプロパティからではなく直接SetValue/GetValueメソッドを呼ぶこともあるらしいので注意。
		///   なので、CLRプロパティの中ではSetValue/GetValueメソッドの呼び出し以外はやらない方が懸命
		/// </summary>
		public int X
		{
			get { return (int)GetValue(XProperty); }
			set { SetValue(XProperty, value); }
		}

		//依存関係のプロパティにはDependencyPropertyクラスを用いる。
		//ただ、DependencyPropertyクラスのインスタンスは辞書のキーを保存するだけみたいなもの。
		//実際に値を格納するのはDependencyObjectクラス(の子クラス)

		/// <summary>
		/// 依存関係プロパティ
		/// 名前は：「プロパティ名 + Property」
		/// 
		/// </summary>
		public static readonly DependencyProperty XProperty = DependencyProperty.Register(
			"X", typeof(int),typeof(DependencyPoint), new UIPropertyMetadata(0));

		//第一引数：プロパティ名
		//第二引数：プロパティの型
		//第三引数：プロパティを定義する型
		//第四引数：メタデータ
	}
}
