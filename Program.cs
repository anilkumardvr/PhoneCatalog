using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Data;
using PhoneCatalog.Models;

var builder = WebApplication.CreateBuilder(args);

// Razor Pages
builder.Services.AddRazorPages();

// EF Core Sqlite
builder.Services.AddDbContext<PhoneDbContext>(opt =>
    opt.UseSqlite("Data Source=phones.db"));

var app = builder.Build();

// Create & seed DB
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PhoneDbContext>();
    db.Database.EnsureCreated();

    if (!db.Phones.Any())
    {
        db.Phones.AddRange(SeedPhones());
        db.SaveChanges();
    }
}

// Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();

// ----- Seed data (20 phones with web images) -----
static List<Phone> SeedPhones() => new()
{
    new Phone { Brand="Apple",   Model="iPhone 15 Pro",     Price=1499,  ImageUrl="https://images.unsplash.com/photo-1695043240420-7a7d1ac8b0e2?auto=format&w=1200&q=80", Rating=4.7, Description="Titanium frame, A17 Pro, Pro camera." },
    new Phone { Brand="Samsung", Model="Galaxy S24 Ultra",  Price=1599,  ImageUrl="https://images.unsplash.com/photo-1706239233930-0d1f672a0c38?auto=format&w=1200&q=80", Rating=4.6, Description="200MP camera, S Pen, all-day battery." },
    new Phone { Brand="Google",  Model="Pixel 8 Pro",       Price=1199,  ImageUrl="https://images.unsplash.com/photo-1696523533756-0f7e1d8f9ef7?auto=format&w=1200&q=80", Rating=4.5, Description="Tensor G3, clean Android, AI features." },
    new Phone { Brand="OnePlus", Model="12",                Price=999,   ImageUrl="https://images.unsplash.com/photo-1610945415295-5b0a1b1b1f3f?auto=format&w=1200&q=80", Rating=4.4, Description="Fast charging, smooth OxygenOS." },
    new Phone { Brand="Xiaomi",  Model="14 Pro",            Price=1099,  ImageUrl="https://images.unsplash.com/photo-1546054454-aa26e2b734d3?auto=format&w=1200&q=80", Rating=4.3, Description="Leica tuning, bright display." },
    new Phone { Brand="Sony",    Model="Xperia 1 V",        Price=1399,  ImageUrl="https://images.unsplash.com/photo-1586936893354-362ad3c11fd1?auto=format&w=1200&q=80", Rating=4.2, Description="4K OLED, pro-grade camera controls." },
    new Phone { Brand="Motorola",Model="Edge 40 Pro",       Price=899,   ImageUrl="https://images.unsplash.com/photo-1592899677977-9c10ca588bb7?auto=format&w=1200&q=80", Rating=4.1, Description="Clean Android, 165Hz display." },
    new Phone { Brand="Nokia",   Model="X30",               Price=599,   ImageUrl="https://images.unsplash.com/photo-1527866959252-deab85ef7d07?auto=format&w=1200&q=80", Rating=3.9, Description="Eco materials, solid build." },
    new Phone { Brand="Asus",    Model="ROG Phone 7",       Price=1299,  ImageUrl="https://images.unsplash.com/photo-1592899677964-3d0f5baba3fb?auto=format&w=1200&q=80", Rating=4.4, Description="Gaming beast, AirTrigger controls." },
    new Phone { Brand="Huawei",  Model="P60 Pro",           Price=1299,  ImageUrl="https://images.unsplash.com/photo-1580906855280-95c2bd2a8b5a?auto=format&w=1200&q=80", Rating=4.3, Description="Excellent cameras, premium design." },
    new Phone { Brand="Oppo",    Model="Find X6 Pro",       Price=1199,  ImageUrl="https://images.unsplash.com/photo-1557180295-76eee20ae8aa?auto=format&w=1200&q=80", Rating=4.2, Description="Hasselblad tuning, curved screen." },
    new Phone { Brand="Vivo",    Model="X100 Pro",          Price=1199,  ImageUrl="https://images.unsplash.com/photo-1523474253046-8cd2748b5fd2?auto=format&w=1200&q=80", Rating=4.3, Description="Zeiss optics, strong night mode." },
    new Phone { Brand="Realme",  Model="GT 5",              Price=699,   ImageUrl="https://images.unsplash.com/photo-1533228100845-08145b01de14?auto=format&w=1200&q=80", Rating=4.0, Description="Value flagship, very fast charging." },
    new Phone { Brand="Honor",   Model="Magic 6 Pro",       Price=1199,  ImageUrl="https://images.unsplash.com/photo-1582548929096-54f398ad44a9?auto=format&w=1200&q=80", Rating=4.2, Description="Curved OLED, big battery." },
    new Phone { Brand="Nothing", Model="Phone (2)",         Price=949,   ImageUrl="https://images.unsplash.com/photo-1657823470702-0b9d5d2b94a8?auto=format&w=1200&q=80", Rating=4.1, Description="Glyph interface, clean Android." },
    new Phone { Brand="Tecno",   Model="Phantom X2 Pro",    Price=699,   ImageUrl="https://images.unsplash.com/photo-1611259183921-52c1f3b5f07f?auto=format&w=1200&q=80", Rating=3.9, Description="Pop-out portrait lens, unique design." },
    new Phone { Brand="Infinix", Model="Zero Ultra",        Price=649,   ImageUrl="https://images.unsplash.com/photo-1529619768328-e37af76c6fe5?auto=format&w=1200&q=80", Rating=3.8, Description="180W charging, large display." },
    new Phone { Brand="ZTE",     Model="Axon 50 Ultra",     Price=899,   ImageUrl="https://images.unsplash.com/photo-1606229365485-93a9a93dba8e?auto=format&w=1200&q=80", Rating=3.9, Description="Under-display camera tech." },
    new Phone { Brand="Lenovo",  Model="Legion Y90",        Price=999,   ImageUrl="https://images.unsplash.com/photo-1542751371-adc38448a05e?auto=format&w=1200&q=80", Rating=4.0, Description="Cooling for gaming, stereo speakers." },
    new Phone { Brand="Meizu",   Model="20 Pro",            Price=799,   ImageUrl="https://images.unsplash.com/photo-1609599006353-91c5fd40f5c7?auto=format&w=1200&q=80", Rating=3.8, Description="Clean design, smooth UI." },
};
