import React from 'react';
import { AntDesign } from '@expo/vector-icons';
import { StyleSheet } from 'react-native';
import { useTheme } from '@react-navigation/native';
import * as Haptics from 'expo-haptics';




function TeacherDetailsScreen({ navigation, route }) {
    const { margin, colors } = useTheme();

    const goBack = () => {
        navigation.goBack();
        Haptics.selectionAsync();
      };

    const styles = StyleSheet.create({
        closeIcon: {
            zIndex: 10,
            top: margin,
            right: margin,
            opacity: 0.75,
            color: colors.text,
            position: 'absolute',
          },
    })

    return (
        <AntDesign size={27} name="close" onPress={goBack} style={styles.closeIcon} />

    );
}

export default TeacherDetailsScreen;