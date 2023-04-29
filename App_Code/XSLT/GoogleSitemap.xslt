<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<urlset xmlns="http://www.google.com/schemas/sitemap/0.84">
			<xsl:for-each select="Products/Product">
				<url>
					<loc><xsl:value-of select="concat('',ref)"/></loc>
					<lastmod>$$dateplaceholder$$</lastmod>
					<changefreq>weekly</changefreq>
					<priority>1.0</priority>
				</url>
			</xsl:for-each>
		</urlset>
	</xsl:template>
</xsl:stylesheet>
