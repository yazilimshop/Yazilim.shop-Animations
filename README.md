# 🎨 Yazilim.shop WPF Animasyon Kütüphanesi

Bu kapsamlı WPF animasyon kütüphanesi, modern ve etkileyici kullanıcı arayüzleri oluşturmak için tasarlanmıştır.

## 📚 Animasyon Kategorileri

### 🎯 Temel Animasyonlar

#### **ObjectShiftAnimations** - Hareket Animasyonları
```csharp
// Elementi belirli koordinatlara hareket ettir
ObjectShiftAnimations.ObjectShift(myButton, 100, 50, 0.5);
ObjectShiftAnimations.ObjectShiftTransform(myPanel, 200, 100, 1.0);
```

#### **FadeAnimations** - Görünme/Kaybolma
```csharp
// Fade efektleri
FadeAnimations.FadeIn(myPanel, 0.8);
FadeAnimations.FadeOut(myButton, 0.6);
FadeAnimations.FadeTo(myTextBlock, 0.3, 1.0);
```

#### **ScaleAnimations** - Boyut Değiştirme
```csharp
// Scale animasyonları
ScaleAnimations.ScaleIn(myButton, 0.5);
ScaleAnimations.ScaleOut(myPanel, 0.7);
ScaleAnimations.ScaleTo(myImage, 1.5, 0.8);
```

#### **RotationAnimations** - Döndürme
```csharp
// Rotation animasyonları
RotationAnimations.Rotate45(myButton, 0.6);
RotationAnimations.Rotate90(myPanel, 0.8);
RotationAnimations.Rotate180(myImage, 1.0);
RotationAnimations.Rotate360(myTextBlock, 2.0);
RotationAnimations.Spin(myButton, 3.0, 2);
RotationAnimations.Wobble(myPanel, 0.5);
```

#### **SlideAnimations** - Kaydırma
```csharp
// Slide animasyonları
SlideAnimations.SlideInFromLeft(myPanel, 0.8);
SlideAnimations.SlideInFromRight(myButton, 0.6);
SlideAnimations.SlideInFromTop(myImage, 0.7);
SlideAnimations.SlideInFromBottom(myTextBlock, 0.5);
SlideAnimations.SlideOutToLeft(myPanel, 0.8);
SlideAnimations.SlideOutToRight(myButton, 0.6);
SlideAnimations.SlideOutToTop(myImage, 0.7);
SlideAnimations.SlideOutToBottom(myTextBlock, 0.5);
```

### 🌟 Gelişmiş Animasyonlar

#### **BlurAnimations** - Bulanıklaştırma Efektleri
```csharp
// Blur animasyonları
BlurAnimations.BlurIn(myPanel, 0.8);
BlurAnimations.BlurOut(myButton, 0.6);
BlurAnimations.BlurTo(myImage, 10.0, 1.0);
BlurAnimations.BlurPulse(myTextBlock, 0.8, 2);
```

#### **ShadowAnimations** - Gölge Efektleri
```csharp
// Shadow animasyonları
ShadowAnimations.ShadowIn(myButton, 0.8);
ShadowAnimations.ShadowOut(myPanel, 0.6);
ShadowAnimations.ShadowMove(myImage, 20.0, 1.0);
ShadowAnimations.ShadowPulse(myTextBlock, 1.2, 2);
ShadowAnimations.GlowShadow(myButton, Colors.Blue, 1.0);
```

#### **TextAnimations** - Metin Animasyonları
```csharp
// Text animasyonları
TextAnimations.Typewriter(myTextBlock, "Merhaba Dünya!", 2.0);
TextAnimations.TextFadeIn(myTextBlock, 0.8);
TextAnimations.TextSlideIn(myTextBlock, 0.8);
TextAnimations.TextBounce(myTextBlock, 0.6);
```

#### **ParticleAnimations** - Parçacık Efektleri
```csharp
// Particle animasyonları
ParticleAnimations.Sparkle(myButton, 8, 1.5);
ParticleAnimations.Confetti(myPanel, 15, 2.0);
ParticleAnimations.Fireworks(myButton, 20, 2.5);
ParticleAnimations.Bubble(myImage, 6, 2.0);
```

#### **PathAnimations** - Yol Animasyonları
```csharp
// Path animasyonları
PathAnimations.CircularMotion(myButton, 100, 2.0);
PathAnimations.WaveMotion(myPanel, 50, 2.0);
PathAnimations.SpiralMotion(myImage, 150, 3.0);
PathAnimations.ZigzagMotion(myTextBlock, 100, 2.0);
```

#### **MorphAnimations** - Şekil Değiştirme
```csharp
// Morph animasyonları
MorphAnimations.Squash(myButton, 0.6);
MorphAnimations.Stretch(myPanel, 0.8);
MorphAnimations.Squeeze(myImage, 0.6);
MorphAnimations.MorphTo(myTextBlock, 1.5, 0.8, 0.8);
MorphAnimations.ElasticMorph(myButton, 1.0);
```

#### **ColorAnimations** - Renk Animasyonları
```csharp
// Color animasyonları
ColorAnimations.AnimateBackgroundColorFromHex(myButton, "#FF0000", 1.0);
ColorAnimations.AnimateForegroundColorFromRgb(myTextBlock, 255, 0, 0, 1.0);
ColorAnimations.AnimateBorderColorFromArgb(myPanel, 255, 0, 0, 255, 1.0);
ColorAnimations.RainbowBackground(myButton, 3.0);
ColorAnimations.PulseColor(myPanel, Colors.Blue, 1.0);
```

### 🎪 Özel Efekt Animasyonları

#### **BounceAnimations** - Zıplama
```csharp
// Bounce animasyonları
BounceAnimations.BounceIn(myButton, 0.6);
BounceAnimations.BounceOut(myPanel, 0.8);
BounceAnimations.BounceUp(myImage, 0.5);
BounceAnimations.BounceDown(myTextBlock, 0.7);
```

#### **ShakeAnimations** - Sallama
```csharp
// Shake animasyonları
ShakeAnimations.Shake(myButton, 0.5);
ShakeAnimations.ShakeVertical(myPanel, 0.6);
ShakeAnimations.ShakeRotate(myImage, 0.4);
ShakeAnimations.Wobble(myTextBlock, 0.8);
ShakeAnimations.Jelly(myButton, 0.6);
```

#### **FlipAnimations** - Çevirme
```csharp
// Flip animasyonları
FlipAnimations.FlipHorizontal(myButton, 0.8);
FlipAnimations.FlipVertical(myPanel, 0.6);
FlipAnimations.FlipIn(myImage, 0.7);
FlipAnimations.FlipOut(myTextBlock, 0.5);
FlipAnimations.Flip3D(myButton, 0.8);
```

#### **HeartbeatAnimations** - Nabız
```csharp
// Heartbeat animasyonları
HeartbeatAnimations.Heartbeat(myButton, 0.8, 2);
HeartbeatAnimations.Pulse(myPanel, 0.6, 3);
```

## 🔧 Animasyon Kontrolü

### Temel Kontroller
```csharp
// Belirli bir elementin animasyonunu durdur
AnimationManager.StopAnimation(myButton);

// Tüm animasyonları durdur
AnimationManager.StopAllAnimations();

// Elementin animasyon durumunu kontrol et
bool isAnimating = AnimationManager.IsAnimating(myButton);

// Animasyon tamamlandığında callback
AnimationManager.OnAnimationCompleted += (element) => {
    Console.WriteLine($"Animasyon tamamlandı: {element.Name}");
};
```

### Easing Functions
```csharp
// Farklı easing fonksiyonları
var elasticEase = new ElasticEase { Oscillations = 2, Springiness = 3 };
var bounceEase = new BounceEase { Bounces = 3, Bounciness = 2 };
var cubicEase = new CubicEase { EasingMode = EasingMode.EaseInOut };

// Kullanım
FadeAnimations.FadeIn(myButton, 0.8, elasticEase);
```

## 🛡️ Güvenlik Özellikleri

- **Çakışma Önleme**: Aynı element üzerinde yeni animasyon başlatıldığında, eski animasyon otomatik olarak durdurulur
- **Thread-Safe**: Lock mekanizması ile çoklu thread güvenliği
- **Null Kontrolü**: Null element kontrolü
- **Otomatik Temizlik**: Tamamlanan animasyonlar otomatik olarak temizlenir
- **Error Handling**: Try-catch blokları ile hata yönetimi
- **Memory Management**: Parçacık animasyonları için otomatik bellek temizliği

## 📦 Kurulum

1. Projeyi derleyin
2. Oluşan DLL'i WPF projenize referans olarak ekleyin
3. `using Yazilim.shop_Animations;` direktifini ekleyin

## 🎯 Kullanım Örnekleri

### Basit Animasyon
```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    var button = sender as Button;
    FadeAnimations.FadeIn(button, 0.8);
}
```

### Karmaşık Animasyon
```csharp
private void AnimateButton(Button button)
{
    // Önce fade in
    FadeAnimations.FadeIn(button, 0.5);
    
    // Sonra scale
    ScaleAnimations.ScaleIn(button, 0.8);
    
    // En son glow shadow
    ShadowAnimations.GlowShadow(button, Colors.Gold, 1.0);
}
```

### Particle Efekti
```csharp
private void CelebrateButton_Click(object sender, RoutedEventArgs e)
{
    var button = sender as Button;
    
    // Konfeti efekti
    ParticleAnimations.Confetti(button, 20, 2.0);
    
    // Havai fişek efekti
    ParticleAnimations.Fireworks(button, 25, 2.5);
}
```

### Text Animasyonu
```csharp
private void AnimateText(TextBlock textBlock)
{
    // Daktilo efekti
    TextAnimations.Typewriter(textBlock, "Hoş geldiniz!", 2.0);
    
    // Sonra bounce efekti
    TextAnimations.TextBounce(textBlock, 0.6);
}
```

## 📊 Animasyon İstatistikleri

- **Toplam Kategori**: 15
- **Toplam Animasyon**: 100+
- **Temel Animasyonlar**: 8 kategori
- **Gelişmiş Animasyonlar**: 7 kategori
- **Particle Efektleri**: 4 farklı efekt
- **Color Desteği**: Hex, RGB, ARGB formatları
- **3D Efektler**: 5 farklı 3D animasyon

## 🚀 Performans İpuçları

1. **Animasyon Çakışmalarını Önleyin**: Aynı element üzerinde birden fazla animasyon çalıştırmayın
2. **Memory Management**: Particle animasyonları otomatik olarak temizlenir
3. **Thread Safety**: Animasyonlar thread-safe olarak tasarlanmıştır
4. **Error Handling**: Tüm animasyonlar try-catch blokları ile korunur

## 🎨 Özel Efektler

### Rainbow Background
```csharp
// Sürekli renk değişimi
ColorAnimations.RainbowBackground(myButton, 3.0);
```

### Elastic Morph
```csharp
// Elastik şekil değiştirme
MorphAnimations.ElasticMorph(myPanel, 1.0);
```

### Fireworks Effect
```csharp
// Havai fişek efekti
ParticleAnimations.Fireworks(myButton, 20, 2.5);
```

Bu kapsamlı animasyon kütüphanesi ile WPF uygulamalarınızda profesyonel ve etkileyici animasyonlar oluşturabilirsiniz! 🎉 
