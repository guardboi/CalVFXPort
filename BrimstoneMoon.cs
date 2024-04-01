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
            if (projectile.type == ModContent.ProjectileType<BrimstoneMonster>() && CalVFXPortConfig.Instance.BrimMonsterRedesign)
            {
                if (!CalVFXPortConfig.Instance.BrimMonsterRedesign)
                {
                    Texture2D moon = ModContent.Request<Texture2D>("CalamityMod/Projectiles/Boss/BrimstoneMonster").Value;
                    Main.EntitySpriteDraw(moon, projectile.Center - Main.screenPosition, default(Rectangle?), Color.White * projectile.Opacity, 0f, Utils.Size(moon) / 2f, 1f, 0, 0);
                    return false;
                }
                Texture2D circle = ModContent.Request<Texture2D>("CalVFXPort/Assets/circle90").Value;
                Texture2D softCircle = ModContent.Request<Texture2D>("CalVFXPort/Assets/circle0").Value;
                Texture2D line = ModContent.Request<Texture2D>("CalVFXPort/Assets/line").Value;
                float pulserate = 45f;
                float scale = 360f / Utils.Size(circle).X;
                float pulse = Math.Abs((float)projectile.timeLeft % pulserate - pulserate / 2f) / pulserate / 2f * 0.1f + 0.9f;
                float num = Math.Abs(((float)projectile.timeLeft + pulserate / 2f) % pulserate - pulserate / 2f) / pulserate / 2f;
                float rot = MathHelper.ToRadians((float)projectile.timeLeft) * CalVFXPortConfig.Instance.BrimMonsterSpeed;
                for (int i = 0; i < 20; i++)
                {
                    Main.EntitySpriteDraw(circle, projectile.Center - Main.screenPosition, default(Rectangle?), new Color(66, 31, 69) * 0.1f, 0f, Utils.Size(circle) / 2f, (float)(20 - i) / 20f * 1.01f * pulse * scale, 0, 0);
                }
                for (int j = 0; j < 10; j++)
                {
                    Main.EntitySpriteDraw(softCircle, projectile.Center - Main.screenPosition, default(Rectangle?), new Color(227, 79, 79) * 0.1f, 0f, Utils.Size(circle) / 2f, (float)(10 - j) / 10f * 0.9f * pulse * scale, 0, 0);
                }
                for (int k = 0; k < 5; k++)
                {
                    Vector2 vect = Utils.RotatedBy(new Vector2(86f, 0f), (double)(MathHelper.ToRadians((float)(k * 72)) + rot + MathHelper.ToRadians(-90f)), default(Vector2));
                    Main.EntitySpriteDraw(line, projectile.Center - Main.screenPosition + vect * pulse * scale, default(Rectangle?), new Color(66, 31, 69), MathHelper.ToRadians((float)(k * 72)) + rot + MathHelper.ToRadians(-90f), Utils.Size(line) / 2f, 0.8f * scale, 0, 0);
                }
                if (CalVFXPortConfig.Instance.BrimMonsterSpeed > 0f)
                {
                    for (int l = 0; l < 6; l++)
                    {
                        int amount = 12;
                        for (int m = 0; m < amount; m++)
                        {
                            float v = (float)projectile.timeLeft + 8f * ((float)m / CalVFXPortConfig.Instance.BrimMonsterSpeed);
                            float s = CalVFXPortConfig.Instance.BrimMonsterSpeed;
                            Vector2 vect2 = (Utils.RotatedBy(new Vector2(80f, 0f), (double)MathHelper.ToRadians(v * s), default(Vector2)) + Utils.RotatedBy(new Vector2(0f, 70f), (double)MathHelper.ToRadians(v * (s / 5f)), default(Vector2))) * 2f;
                            Main.EntitySpriteDraw(softCircle, projectile.Center - Main.screenPosition + Utils.RotatedBy(vect2, (double)(MathHelper.ToRadians((float)(l * 120)) + rot), default(Vector2)) * pulse * scale, default(Rectangle?), new Color(255, 145, 115) * 0.75f * ((float)(amount - m) / (float)amount), 0f, Utils.Size(circle) / 2f, 0.05f * scale * ((float)(m - amount) / (float)amount), 0, 0);
                        }
                    }
                    for (int n = 0; n < 6; n++)
                    {
                        int amount2 = 18;
                        for (int i2 = 0; i2 < amount2; i2++)
                        {
                            float v2 = -((float)projectile.timeLeft + (float)i2 / CalVFXPortConfig.Instance.BrimMonsterSpeed);
                            float s2 = 3f * CalVFXPortConfig.Instance.BrimMonsterSpeed;
                            Vector2 vect3 = (Utils.RotatedBy(new Vector2(90f, 0f), (double)MathHelper.ToRadians(v2 * s2), default(Vector2)) + Utils.RotatedBy(new Vector2(0f, 60f), (double)MathHelper.ToRadians(v2 * (s2 / 5f)), default(Vector2))) * 2.5f;
                            Main.EntitySpriteDraw(softCircle, projectile.Center - Main.screenPosition + Utils.RotatedBy(vect3, (double)(MathHelper.ToRadians((float)(n * 60)) + rot), default(Vector2)) * pulse * scale, default(Rectangle?), new Color(138, 32, 48) * ((float)(amount2 - i2) / (float)amount2), 0f, Utils.Size(circle) / 2f, 0.05f * scale * ((float)(i2 - amount2) / (float)amount2), 0, 0);
                        }
                    }
                    for (int m2 = 0; m2 < 6; m2++)
                    {
                        int amount3 = 18;
                        for (int i3 = 0; i3 < amount3; i3++)
                        {
                            float v3 = (float)projectile.timeLeft + 180f * CalVFXPortConfig.Instance.BrimMonsterSpeed + (float)i3 / CalVFXPortConfig.Instance.BrimMonsterSpeed;
                            float s3 = 3f * CalVFXPortConfig.Instance.BrimMonsterSpeed;
                            Vector2 vect4 = (Utils.RotatedBy(new Vector2(90f, 0f), (double)MathHelper.ToRadians(v3 * s3), default(Vector2)) + Utils.RotatedBy(new Vector2(0f, 60f), (double)MathHelper.ToRadians(v3 * (s3 / 5f)), default(Vector2))) * 2.5f;
                            Main.EntitySpriteDraw(softCircle, projectile.Center - Main.screenPosition + Utils.RotatedBy(vect4, (double)(MathHelper.ToRadians((float)(m2 * 60)) + rot), default(Vector2)) * pulse * scale, default(Rectangle?), new Color(138, 32, 48) * ((float)(amount3 - i3) / (float)amount3), 0f, Utils.Size(circle) / 2f, 0.05f * scale * ((float)(i3 - amount3) / (float)amount3), 0, 0);
                        }
                    }
                }
                return false;
            }
            else
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
}
