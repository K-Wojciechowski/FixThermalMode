<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:wix="http://wixtoolset.org/schemas/v4/wxs"
  xmlns="http://wixtoolset.org/schemas/v4/wxs">
  <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>

  <!-- https://stackoverflow.com/a/58716185 -->
  <!-- Template for the new ServiceInstall element -->
  <xsl:param name="pServiceInstall">
    <xsl:element name="ServiceInstall">
      <xsl:attribute name="Id">SVINSTL_FixThermalMode</xsl:attribute>
      <xsl:attribute name="Description">Background service/API for Fix Thermal Mode application</xsl:attribute>
      <xsl:attribute name="Account">LocalSystem</xsl:attribute>
      <xsl:attribute name="DisplayName">Fix Thermal Mode</xsl:attribute>
      <xsl:attribute name="ErrorControl">normal</xsl:attribute>
      <xsl:attribute name="Name">FixThermalMode</xsl:attribute>
      <xsl:attribute name="Interactive">no</xsl:attribute>
      <xsl:attribute name="Start">auto</xsl:attribute>
      <xsl:attribute name="Type">ownProcess</xsl:attribute>
      <xsl:attribute name="Vital">yes</xsl:attribute>
    </xsl:element>
  </xsl:param>

  <!-- Template for the new ServiceControl element -->
  <xsl:param name="pServiceControl">
    <xsl:element name="ServiceControl">
      <xsl:attribute name="Id">SVCTRL_FixThermalMode</xsl:attribute>
      <xsl:attribute name="Name">FixThermalMode</xsl:attribute>
      <xsl:attribute name="Start">install</xsl:attribute>
      <xsl:attribute name="Stop">both</xsl:attribute>
      <xsl:attribute name="Remove">uninstall</xsl:attribute>
      <xsl:attribute name="Wait">yes</xsl:attribute>
    </xsl:element>
  </xsl:param>


  <!-- Insert the ServiceInstall and ServiceControl elements into the component with the exe file -->
  <xsl:template match="//wix:File[@Source='SourceDir\api\FixThermalMode.Api.exe']">
    <xsl:call-template name="identity" />
    <xsl:copy-of select="$pServiceInstall"/>
    <xsl:copy-of select="$pServiceControl"/>
  </xsl:template>

  <!-- Identity template (copies everything as is) -->
  <xsl:template match="@*|node()" name="identity">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()" />
    </xsl:copy>
  </xsl:template>

</xsl:stylesheet>
