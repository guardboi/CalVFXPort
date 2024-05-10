using System;
using CalamityMod;
using CalamityMod.CalPlayer;
using CalamityMod.Projectiles.Boss;
using CalamityMod.Projectiles.Typeless;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CalVFXPort
{
    public class BrimstoneMoon : GlobalProjectile
    {
        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            if (projectile.type == ModContent.ProjectileType<OmegaBlueTentacle>() && CalVFXPortConfig.Instance.DrawLimit_OBTentacle > 0)
            {
                Player player = Main.player[projectile.owner];
                Texture2D circle2 = ModContent.Request<Texture2D>("CalVFXPort/Assets/circle").Value;
                Texture2D value = ModContent.Request<Texture2D>("CalamityMod/Projectiles/Typeless/OmegaBlueTentacle").Value;
                    projectile.rotation = Utils.ToRotation(projectile.Center - CalamityUtils.ModProjectile<OmegaBlueTentacle>(projectile).segment[5]);
                    float scale2 = 8f / Utils.Size(circle2).X;
                    int tcount = CalVFXPortConfig.Instance.DrawLimit_OBTentacle;
                    Color white = Color.White;
                    Color tentacleColor = new Color(67, 72, 81);
                    Color insideColor = new Color(255, 205, 0);
                    if (Main.player[projectile.owner].GetModPlayer<CalamityPlayer>().omegaBlueHentai)
                    {
                        insideColor = new Color(255, 0, 255);
                    }
                    if (tcount > 1)
                    {
                        for (int i4 = 0; i4 < tcount; i4++)
                        {
                            float wigglestrength = ((i4 < tcount / 2) ? ((float)Math.Log((double)(i4 + 1), (double)tcount)) : ((float)Math.Log((double)(tcount - i4 + 1), (double)tcount))) * 5f;
                            Main.EntitySpriteDraw(circle2, projectile.Center - Main.screenPosition - (projectile.Center - player.Center) * ((float)i4 / (float)tcount) - projectile.velocity * wigglestrength, default(Rectangle?), tentacleColor * (1f - (float)i4 / (float)tcount), 0f, Utils.Size(circle2) / 2f, 1f * scale2, 0, 0);
                        }
                        for (int i5 = 0; i5 < tcount; i5++)
                        {
                            float wigglestrength2 = ((i5 < tcount / 2) ? ((float)Math.Log((double)(i5 + 1), (double)tcount)) : ((float)Math.Log((double)(tcount - i5 + 1), (double)tcount))) * 5f;
                            Main.EntitySpriteDraw(circle2, projectile.Center - Main.screenPosition - (projectile.Center - player.Center) * ((float)i5 / (float)tcount) - projectile.velocity * wigglestrength2, default(Rectangle?), insideColor * (1f - (float)i5 / (float)tcount), 0f, Utils.Size(circle2) / 2f, 0.25f * scale2, 0, 0);
                        }
                    }
                    else
                    {
                        Main.EntitySpriteDraw(circle2, projectile.Center - Main.screenPosition, default(Rectangle?), tentacleColor, 0f, Utils.Size(circle2) / 2f, 1f * scale2, 0, 0);
                        Main.EntitySpriteDraw(circle2, projectile.Center - Main.screenPosition, default(Rectangle?), insideColor, 0f, Utils.Size(circle2) / 2f, 0.25f * scale2, 0, 0);
                    }
                    return false;
                }
            return base.PreDraw(projectile, ref lightColor);
        }
    }
}
